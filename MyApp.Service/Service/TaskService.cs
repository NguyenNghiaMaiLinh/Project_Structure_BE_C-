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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper, ITaskRepository taskRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = taskRepository;
            _mapper = mapper;
        }

        public BaseViewModel<TaskViewPage> changeStatus(string id, TaskChangeStatusViewPage request)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            else if (entity.CreateBy != _repository.GetUsername())
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.INVALID_PERMISSION,
                    Data = null,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.SetDefaultUpdateValue(_repository.GetUsername());
            entity.Status = request.Status;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<TaskViewPage>
            {
                Data = _mapper.Map<TaskViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<IEnumerable<TaskViewPage>> create(TaskCreateViewPage request)
        {
            var list = new List<Task>();
            foreach (var item in request.tasks)
            {
                var entity = new Task();
                entity.SetDefaultInsertValue(_repository.GetUsername());
                entity.IsDelete = false;
                entity.IsMain = true;
                entity.PositionInWorkflow = item.PositionInWorkflow;
                entity.TaskName = item.TaskName;
                entity.Status = MyEnum.Status.None;
                entity.TaskMainId = entity.Id;
                entity.WorkflowId = request.WorkflowId;
                list.Add(entity);
            }
            _repository.AddBulk(list);
            Save();
            return new BaseViewModel<IEnumerable<TaskViewPage>>
            {
                Data = _mapper.Map<IEnumerable<TaskViewPage>>(list),
                StatusCode = HttpStatusCode.Created
            };
        }

        public BaseViewModel<TaskViewPage> createIntance(TaskCreateInstanceViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            var task = new Task();
            task.SetDefaultInsertValue(_repository.GetUsername());
            task.IsMain = false;
            task.IsDelete = false;
            task.PositionInWorkflow = entity.PositionInWorkflow;
            task.TaskName = entity.TaskName;
            task.TaskMainId = entity.Id;
            task.Status = MyEnum.Status.Started;
            return new BaseViewModel<TaskViewPage>
            {
                Data = _mapper.Map<TaskViewPage>(task),
                StatusCode = HttpStatusCode.Created
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
            entity.SetDefaultUpdateValue(_repository.GetUsername());
            entity.IsDelete = true;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<bool>
            {
                Data = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<PagingResult<TaskViewPage>> getAllTask(BasePagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<TaskViewPage>>();

            var data = _repository.getAllTask(pageIndex, pageSize, request.Search).ToList();
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
                result.Data = new PagingResult<TaskViewPage>
                {
                    Results = _mapper.Map<IEnumerable<TaskViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<TaskViewPage> getTaskById(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<TaskViewPage>
            {
                Data = _mapper.Map<TaskViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<TaskViewPage> update(TaskUpdateViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            else if (entity.CreateBy != _repository.GetUsername())
            {
                return new BaseViewModel<TaskViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.INVALID_PERMISSION,
                    Data = null,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.SetDefaultUpdateValue(_repository.GetUsername());
            entity.TaskName = request.TaskName;
            entity.PositionInWorkflow = request.PositionInWorkflow;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<TaskViewPage>
            {
                Data = _mapper.Map<TaskViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
