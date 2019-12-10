using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Service.Service
{
    public class WorkflowMemberService : IWorkflowMemberService
    {
        private readonly IWorkflowMembersRepository _repository;
        private readonly IWorkflowRepository _workflowRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkflowMemberService(IUnitOfWork unitOfWork, IMapper mapper, IWorkflowMembersRepository workflowMembersRepository, IUserRepository userRepository, IWorkflowRepository workflowRepository)
        {
            _unitOfWork = unitOfWork;
            _workflowRepository = workflowRepository;
            _userRepository = userRepository;
            _repository = workflowMembersRepository;
            _mapper = mapper;
        }

        public async Task<BaseViewModel<WorkflowMemberViewPage>> addMember(WorkflowMemberCreateViewPage request)
        {
            PushNotification push = new PushNotification();
            var member = _userRepository.GetById(request.UserId);
            var workflow = _workflowRepository.GetById(request.WorkflowMainId);
            var workflowMember = _repository.checkExisted(request.UserId, request.WorkflowMainId);
            if (member == null)
            {
                return new BaseViewModel<WorkflowMemberViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.ACCOUNTNOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            else if (workflow == null)
            {
                return new BaseViewModel<WorkflowMemberViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.WORKFLOWNOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            else if (workflowMember != null)
            {
                return new BaseViewModel<WorkflowMemberViewPage>
                {
                    Code = MessageConstants.FAILURE,
                    Description = ErrMessageConstants.ACCOUNT_ALREADY_EXISTED,
                    Data = null,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            var entity = new WorkflowMember();
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.UserId = request.UserId;
            entity.WorkflowMainId = request.WorkflowMainId;
            entity.IsDelete = false;
            _repository.Add(entity);

           await push.NotifyAsync(member.DeviceToken, workflow.WorkflowName,"Bạn đã được thêm trong workflow "+ workflow.WorkflowName+" bởi "+_repository.GetUsername());

            Save();
            return new BaseViewModel<WorkflowMemberViewPage>
            {
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<WorkflowMemberViewPage>(workflowMember)
            };
        }

        public BaseViewModel<PagingResult<Account>> getAllMember(MemberPagingRequestViewModel request)
        {

            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<Account>>();

            var data = _repository.getAllMemberByWorkflowId(pageIndex, pageSize, _repository.GetUsername(), request.Search).ToList();
            if (data == null || data.Count == 0)
            {
                result.Description = MessageConstants.NO_RECORD;
                result.Code = MessageConstants.NO_RECORD;
            }
            else
            {
                var pageSizeReturn = pageSize;
                if (data.Count < pageSize)
                {
                    pageSizeReturn = data.Count;
                }
                result.Data = new PagingResult<Account>
                {
                    Results = _mapper.Map<IEnumerable<Account>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
