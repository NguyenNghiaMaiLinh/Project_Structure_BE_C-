using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service.HelperService;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MyApp.Service.Service
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _repository;
        private readonly IWorkflowMembersRepository _projectMembersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkflowService(IUnitOfWork unitOfWork, IMapper mapper, IWorkflowRepository projectRepository, IWorkflowMembersRepository projectMembersRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = projectRepository;
            _projectMembersRepository = projectMembersRepository;
            _mapper = mapper;
        }

        public BaseViewModel<WorkflowViewPage> create(WorkflowCreateViewPage request)
        {
           
            var entity = new Workflow();
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.WorkflowName = request.WorkflowName;
            entity.IsDelete = false;
            _repository.Add(entity);

            var temp = new WorkflowMember();
            temp.SetDefaultInsertValue(_repository.GetUsername());
            temp.IsDelete = false;
            temp.WorkflowMainId = entity.Id;
            temp.UserId = _repository.GetUsername();
            _projectMembersRepository.Add(temp);

            Save();
            return new BaseViewModel<WorkflowViewPage>
            {
                Code = MessageConstants.SUCCESS,
                Description = null,
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<WorkflowViewPage>(entity)
            };
        }

        public BaseViewModel<bool> delete(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<bool>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.SetDefaultUpdateValue(_repository.GetUsername());
            entity.IsDelete = true;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<bool>
            {
                Code = MessageConstants.SUCCESS,
                Description = null,
                Data = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<PagingResult<WorkflowViewPage>> getAllProject(BasePagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<WorkflowViewPage>>();

            var data = _repository.GetAllProject(pageIndex, pageSize, _repository.GetUsername()).ToList();
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
                result.Data = new PagingResult<WorkflowViewPage>
                {
                    Results = _mapper.Map<IEnumerable<WorkflowViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<WorkflowViewPage> update(string id, WorkflowUpdateViewPage request)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<WorkflowViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.SetDefaultUpdateValue(_repository.GetUsername());
            entity.WorkflowName = request.WorkflowName;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<WorkflowViewPage>
            {
                Code = MessageConstants.SUCCESS,
                Description = null,
                Data = _mapper.Map<WorkflowViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
