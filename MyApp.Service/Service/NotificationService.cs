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

namespace MyApp.Service.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper, INotificationRepository notificationRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = notificationRepository;
            _mapper = mapper;
        }

        public BaseViewModel<NotificationViewPage> create(NotificationCreateViewPage request)
        {
            var entity = new Notification();
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.Message = request.Message;
            entity.ImageUrl = request.ImageUrl;
            entity.IsRead = false;
            entity.Receiver = request.Receiver;
            entity.IsDelete = false;
            _repository.Add(entity);

            //TODO: send notification

            Save();
            return new BaseViewModel<NotificationViewPage>
            {
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<NotificationViewPage>(entity)
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
                Data = false,
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<PagingResult<NotificationViewPage>> getAllNotification(BasePagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<NotificationViewPage>>();

            var data = _repository.GetAllNotification(pageIndex, pageSize, _repository.GetUsername(), request.Search).ToList();
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
                result.Data = new PagingResult<NotificationViewPage>
                {
                    Results = _mapper.Map<IEnumerable<NotificationViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<NotificationViewPage> getNotificationById(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<NotificationViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<NotificationViewPage>
            {
                Data = _mapper.Map<NotificationViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<NotificationViewPage> readed(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<NotificationViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.IsRead = true;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<NotificationViewPage>
            {
                Data = _mapper.Map<NotificationViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<NotificationViewPage> update(NotificationUpdateViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<NotificationViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.ImageUrl = request.ImageUrl;
            entity.Message = request.Message;
            entity.Topic = request.Topic;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<NotificationViewPage>
            {
                Data = _mapper.Map<NotificationViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
