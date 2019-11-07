using AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;

namespace MyApp.Service.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper, ICityRepository userRepository)
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
