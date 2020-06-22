using System.Collections.Generic;
using AutoMapper;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Service.Service
{
    public class StepService:IStepService
    {
        private readonly IStepRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StepService(IUnitOfWork unitOfWork, IMapper mapper, IStepRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public void create(List<StepViewPage> request)
        {
            foreach (var item in request)
            {
                var entity = _mapper.Map<Step>(item);
                entity.SetDefaultInsertValue(_repository.GetCurrentUserId());
                _repository.Update(entity);
                Save();
            }
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
