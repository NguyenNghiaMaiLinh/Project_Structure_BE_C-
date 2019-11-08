using AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;

namespace MyApp.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository userRepository)
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
