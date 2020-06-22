using AutoMapper;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Service.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper, IMaterialRepository materialRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = materialRepository;

            _mapper = mapper;
        }
        public void create(List<MaterialViewPage> request)
        {
            foreach (var item in request)
            {
                var entity = _mapper.Map<Material>(item);
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
