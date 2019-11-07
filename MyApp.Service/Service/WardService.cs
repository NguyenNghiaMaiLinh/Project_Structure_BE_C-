using AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;

namespace MyApp.Service.Service
{
    public class WardService : IWardService
    {
        private readonly IWardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WardService(IUnitOfWork unitOfWork, IMapper mapper, IWardRepository userRepository)
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
