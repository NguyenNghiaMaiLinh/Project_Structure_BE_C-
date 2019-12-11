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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IWorkflowMembersRepository _workflowMembersRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IWorkflowRepository _workflowRepository;
        private readonly INotificationRepository _notiRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ICommentRepository commentRepository,IWorkflowMembersRepository workflowMembersRepository,INotificationRepository notificationRepository, IUserRepository userRepository,ITaskRepository taskRepository,IWorkflowRepository workflowRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = commentRepository;
            _taskRepository = taskRepository;
            _workflowRepository = workflowRepository;
            _userRepository = userRepository;
            _notiRepository = notificationRepository;
            _workflowMembersRepository = workflowMembersRepository;
            _mapper = mapper;
        }

        public async Task<BaseViewModel<CommentViewPage>> create(CommentCreateViewPage request)
        {
            PushNotification push = new PushNotification();
            var entity = new Comment();
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.Detail = request.Detail;
            entity.ImageUrl = request.ImageUrl;
            entity.WorkflowMemberId = request.WorkflowMemberId;
            entity.TaskId = request.TaskId;
            entity.IsDelete = false;
            _repository.Add(entity);

            var workflowId = _workflowMembersRepository.GetById(request.WorkflowMemberId).WorkflowMainId;
            var nameWorkflow = _workflowRepository.GetById(workflowId).WorkflowName;
            var nameTask = _taskRepository.GetById(request.TaskId).TaskName;

            var members = _workflowMembersRepository.getAllMemberByWorkflowId(workflowId).ToList();
            foreach (var item in members)
            {
                var account = _userRepository.GetById(_repository.GetUsername());
                var message =  account.FullName + " đã thêm bình luận trong workfow [" + nameWorkflow + "] - task [" + nameTask + "]";
                await push.NotifyAsync(account.DeviceToken, "Comment", message);
                Notification notification = new Notification();
                notification.SetDefaultInsertValue(_repository.GetUsername());
                notification.Message = message;
                notification.ImageUrl = request.ImageUrl;
                notification.IsRead = false;
                notification.Receiver = account.Username;
                notification.Topic = "Comment";
                notification.IsDelete = false;
                _notiRepository.Add(notification);
            }


            Save();
            return new BaseViewModel<CommentViewPage>
            {
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<CommentViewPage>(entity)
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
            else if (entity.CreateBy != _repository.GetUsername())
            {
                return new BaseViewModel<bool>
                {
                    Code = MessageConstants.FAILURE,
                    Description = ErrMessageConstants.INVALID_PERMISSION,
                    Data = false,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.IsDelete = true;
            _repository.Update(entity);
            Save();

            return new BaseViewModel<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Data = true
            };
        }

        public BaseViewModel<PagingResult<CommentViewPage>> getAllComment(CommentPagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<CommentViewPage>>();

            var data = _repository.getAllComment(pageIndex, pageSize, request.TaskId, request.Search).ToList();
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
                var entity = new List<CommentViewPage>();
                entity = _mapper.Map<List<CommentViewPage>>(data);
                foreach (var item in entity)
                {
                    item.Username =  _workflowMembersRepository.GetById(item.WorkflowMemberId).UserId;
                    item.AvatarPath = _userRepository.GetById(item.Username).AvatarPath;
                }
                result.Data = new PagingResult<CommentViewPage>
                {
                    Results = _mapper.Map<IEnumerable<CommentViewPage>>(entity),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<CommentViewPage> getCommentById(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<CommentViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<CommentViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<CommentViewPage>(entity)
            };
        }

        public BaseViewModel<string> getMemberId(string workflowId)
        {
            var entity = _workflowMembersRepository.getMemberId(workflowId,_repository.GetUsername()).Id;
            if (entity == null)
            {
                return new BaseViewModel<string>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<string>
            {
                StatusCode = HttpStatusCode.OK,
                Data = entity
            };
        }

        public BaseViewModel<CommentViewPage> update(CommentUpdateViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<CommentViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.ImageUrl = request.ImageUrl;
            _repository.Update(entity);
            Save();

            return new BaseViewModel<CommentViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<CommentViewPage>(entity)
            };
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
