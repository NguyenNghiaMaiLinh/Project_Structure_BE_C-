using AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;

namespace MyApp.Service.Service
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper, IDistrictRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _mapper = mapper;
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
