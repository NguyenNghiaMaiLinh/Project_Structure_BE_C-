using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service.HelperService;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MyApp.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _mapper = mapper;
        }

        public BaseViewModel<bool> DeleteAccount(string id)
        {
            var currentUser = _repository.GetById(_repository.GetUsername());
            var result = new BaseViewModel<bool>()
            {
                Code = MessageConstants.NOTFOUND,
                Description = MessageConstants.NOTFOUND,
                StatusCode = HttpStatusCode.BadRequest,
                Data = false

            };
            if (currentUser.Role == Role.Admin)
            {
                var account = _repository.GetById(id);
                if (account == null)
                {
                    return result;
                }
                account.IsDelete = true;
                _repository.Update(account);
                Save();
                result.Code = MessageConstants.SUCCESS;
                result.Description = MessageConstants.SUCCESS;
                result.StatusCode = HttpStatusCode.OK;
                result.Data = true;
            }
            else
            {
                result.Code = MessageConstants.FAILURE;
                result.Description = ErrMessageConstants.INVALID_PERMISSION;
                result.StatusCode = HttpStatusCode.PreconditionFailed;
                result.Data = false;
            }

            return result;
        }

        public BaseViewModel<PagingResult<UserViewPage>> GetAllUser(BasePagingRequestViewModel request)
        {

            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<UserViewPage>>();

            var data = _repository.getAllUser(pageIndex, pageSize).ToList();

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
                result.Data = new PagingResult<UserViewPage>
                {
                    Results = _mapper.Map<IEnumerable<UserViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<Account> Login(LoginViewModel user)
        {
            var entity = _repository.GetById(user.Username);
            if (entity == null)
            {
                return new BaseViewModel<Account>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };

            }
            if (!SaltHashPassword.Verify(entity.SaltPassword, entity.HashPassword, user.Password))
            {
                return new BaseViewModel<Account>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Description = ErrMessageConstants.INVALID_ACCOUNT,
                    Code = ErrMessageConstants.INVALID_ACCOUNT,
                    Data = null
                };
            }
            return new BaseViewModel<Account>
            {
                StatusCode = HttpStatusCode.OK,
                Description = null,
                Code = MessageConstants.SUCCESS,
                Data = _mapper.Map<Account>(entity)
            };
        }

        public BaseViewModel<Account> LoginByFacebook(LoginFacebookViewModel user)
        {
            var entity = _repository.GetById(user.Username);
            if (entity == null)
            {
                return new BaseViewModel<Account>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };

            }
            return new BaseViewModel<Account>
            {
                StatusCode = HttpStatusCode.OK,
                Description = null,
                Code = MessageConstants.SUCCESS,
                Data = _mapper.Map<Account>(entity)
            };
        }

        public BaseViewModel<Account> Register(RegisterViewModel user)
        {
            var check = _repository.GetById(user.Username);
            var result = new BaseViewModel<Account>()
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
            var entity = new Account
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                AvatarPath = user.Avatar_Path
            };
            var temp = new SaltHashPassword(user.Password);
            entity.SaltPassword = temp.Salt;
            entity.HashPassword = temp.Hash;
            entity.Role = Role.User;
            entity.IsDelete = false;

            _repository.Add(entity);
            Save();

            result.Code = MessageConstants.SUCCESS;
            result.Description = null;
            result.StatusCode = HttpStatusCode.Created;
            result.Data = _mapper.Map<Account>(entity);
            return result;
        }


        public BaseViewModel<UserViewPage> Update(UserUpdateViewPage user)
        {
            var result = new BaseViewModel<UserViewPage>()
            {
                Code = MessageConstants.NOTFOUND,
                Description = MessageConstants.NOTFOUND,
                StatusCode = HttpStatusCode.OK,
                Data = null

            };

            var entity = _repository.GetById(user.Id);
            if (entity == null)
            {
                return new BaseViewModel<UserViewPage>
                {
                    Data = null
                };
            }
            entity.FullName = user.FullName;
            entity.AvatarPath = user.AvatarPath;
            entity.Email = user.Email;
            _repository.Update(entity);
            Save();

            result.Data = _mapper.Map<UserViewPage>(entity);

            return result;
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
