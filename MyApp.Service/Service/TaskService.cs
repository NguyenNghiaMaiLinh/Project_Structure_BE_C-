using AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

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

        public BaseViewModel<TaskViewPage> create(TaskCreateViewPage request)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<bool> delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<PagingResult<TaskViewPage>> getAllTask(BasePagingRequestViewModel request)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<TaskViewPage> update(string id, TaskUpdateViewPage request)
        {
            throw new System.NotImplementedException();
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
