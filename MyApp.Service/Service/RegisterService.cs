using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Helpers;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Linq;
using System.Net;

namespace MyApp.Service.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _repository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private static readonly string ACCOUNTS = "accounts";

        public RegisterService(IUnitOfWork unitOfWork, IMapper mapper,IRecipeRepository recipeRepository, IRegisterRepository registerRepository,IFollowerRepository followerRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = registerRepository;
            _recipeRepository = recipeRepository;
            _followerRepository = followerRepository;
            _mapper = mapper;
        }
        public BaseViewModel<RegisterViewPage> GetInformation()
        {
            var entity = _repository.GetById(_repository.GetUsername());
            if (entity == null)
            {
                return new BaseViewModel<RegisterViewPage>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };
            }
            var data = _mapper.Map<RegisterViewPage>(entity);
            data.NumberRecipe = _recipeRepository.getAllRecipeByAuthor(_recipeRepository.GetCurrentUserId()).Count();
            data.NumberFollower = _followerRepository.getALlFollowerByAuthor(_repository.GetCurrentUserId()).Count();
            return new BaseViewModel<RegisterViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Description = null,
                Code = MessageConstants.SUCCESS,
                Data = data
            };
        }
      
        public BaseViewModel<Register> Login(LoginViewModel user)
        {
            var entity = _repository.GetById(user.Username);
            if (entity == null)
            {
                return new BaseViewModel<Register>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };

            }
            if (!SaltHashPassword.Verify(entity.SaltPassword, entity.HashPassword, user.Password))
            {
                return new BaseViewModel<Register>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Description = ErrMessageConstants.INVALID_ACCOUNT,
                    Code = ErrMessageConstants.INVALID_ACCOUNT,
                    Data = null
                };
            }
            _repository.Update(entity);
            Save();
            return new BaseViewModel<Register>
            {
                StatusCode = HttpStatusCode.OK,
                Description = null,
                Code = MessageConstants.SUCCESS,
                Data = entity
            };
        }

        public BaseViewModel<Register> Register(RegisterViewModel user)
        {
            var check = _repository.GetById(user.Username);
            var result = new BaseViewModel<Register>()
            {
                Code = MessageConstants.FAILURE,
                Description = ErrMessageConstants.ACCOUNT_ALREADY_EXISTS,
                StatusCode = HttpStatusCode.BadRequest
            };
            if (check != null)
            {
                result.Data = null;
                return result;
            }
            var entity = new Register
            {
                Username = user.Username,
            };
            var temp = new SaltHashPassword(user.Password);
            entity.SaltPassword = temp.Salt;
            entity.HashPassword = temp.Hash;
            entity.Fullname = user.Fullname;
            entity.Role = Role.User;
            entity.IsDelete = false;
            _repository.Add(entity);
            Save();

            result.Code = MessageConstants.SUCCESS;
            result.Description = null;
            result.StatusCode = HttpStatusCode.Created;
            result.Data = _mapper.Map<Register>(entity);
            return result;
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
