using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service.HelperService;
using System;
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

        public BaseViewModel<bool> DeleteAccount(UserDeleteViewPage request)
        {
            var currentUser = _repository.GetByUsername(_repository.GetUsername());
            var result = new BaseViewModel<bool>()
            {
                Code = MessageConstants.NO_RECORD,
                Description = MessageConstants.NO_RECORD,
                StatusCode = HttpStatusCode.OK,
                Data = false

            };
            if (currentUser.Role == Core.Constaint.Role.SuperAdmin)
            {
                var account = _repository.GetById(request.Id);
                if (account != null)
                {
                    account.IsDelete = true;
                    _repository.Update(account);
                    result.Code = MessageConstants.SUCCESS;
                    result.Description = MessageConstants.SUCCESS;
                    result.StatusCode = HttpStatusCode.OK;
                    result.Data = true;
                }
            }
            else
            {
                result.Code = MessageConstants.FAILED;
                result.Description = MessageConstants.FAILED;
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

            var data = _repository.GetAll().ToList();

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
                    TotalRecords = 1
                };
            }

            return result;
        }

        public BaseViewModel<User> Login(LoginViewModel user)
        {
            var entity = _repository.GetByUsername(user.Username);
            if (entity == null)
            {
                return new BaseViewModel<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };

            }
            if (!SaltHashPassword.Verify(entity.SaltPassword, entity.HashPassword, user.Password))
            {
                return new BaseViewModel<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.INVALID_PASSWORD,
                    Code = ErrMessageConstants.INVALID_PASSWORD,
                    Data = null
                };
            }
            var data = _mapper.Map<User>(entity);
            return new BaseViewModel<User>
            {
                Data = data
            };

        }

        public BaseViewModel<User> Register(RegisterViewModel user)
        {
            var check = _repository.GetByUsername(user.Username);
            if (check != null)
            {
                return new BaseViewModel<User>
                {
                    Data = null
                };
            }
            var entity = new User
            {
                Username = user.Username,
                FullName = user.FullName
            };
            entity.SetDefaultInsertValue(user.Username);
            var temp = new SaltHashPassword(user.Password);
            entity.SaltPassword = temp.Salt;
            entity.HashPassword = temp.Hash;
            _repository.Add(entity);
            Save();
            var result = new BaseViewModel<User>()
            {
                Data = _mapper.Map<User>(entity)
            };


            return result;
        }

        public BaseViewModel<UserViewPage> RegisterAdmin(RegisterViewModel user)
        {
            var currentUser = _repository.GetByUsername(_repository.GetUsername());
            var result = new BaseViewModel<UserViewPage>()
            {
                Code = MessageConstants.NO_RECORD,
                Description = MessageConstants.NO_RECORD,
                StatusCode = HttpStatusCode.OK,
                Data = null

            };
            if (currentUser.Role == Core.Constaint.Role.SuperAdmin)
            {
                var check = _repository.GetByUsername(user.Username);
                if (check != null)
                {
                    return new BaseViewModel<UserViewPage>
                    {
                        Data = null
                    };
                }
                var entity = new User
                {
                    Username = user.Username,
                    FullName = user.FullName
                };
                entity.SetDefaultInsertValue(_repository.GetUsername());
                var temp = new SaltHashPassword(user.Password);
                entity.SaltPassword = temp.Salt;
                entity.HashPassword = temp.Hash;
                entity.Role = Core.Constaint.Role.Admin;
                _repository.Add(entity);
                Save();

                result.Data = _mapper.Map<UserViewPage>(entity);
            }
            else
            {
                result.Code = MessageConstants.FAILED;
                result.Description = MessageConstants.FAILED;
                result.StatusCode = HttpStatusCode.PreconditionFailed;
                result.Data = null;
            }

            return result;
        }

        public BaseViewModel<UserViewPage> RegisterStaff(RegisterViewModel user)
        {
            var currentUser = _repository.GetByUsername(_repository.GetUsername());
            var result = new BaseViewModel<UserViewPage>()
            {
                Code = MessageConstants.NO_RECORD,
                Description = MessageConstants.NO_RECORD,
                StatusCode = HttpStatusCode.OK,
                Data = null

            };
            if (currentUser.Role == Core.Constaint.Role.SuperAdmin)
            {
                var check = _repository.GetByUsername(user.Username);
                if (check != null)
                {
                    return new BaseViewModel<UserViewPage>
                    {
                        Data = null
                    };
                }
                var entity = new User
                {
                    Username = user.Username,
                    FullName = user.FullName
                };
                entity.SetDefaultInsertValue(_repository.GetUsername());
                var temp = new SaltHashPassword(user.Password);
                entity.SaltPassword = temp.Salt;
                entity.HashPassword = temp.Hash;
                entity.Role = Core.Constaint.Role.Staff;
                _repository.Add(entity);
                Save();

                result.Data = _mapper.Map<UserViewPage>(entity);
            }
            else
            {
                result.Code = MessageConstants.FAILED;
                result.Description = MessageConstants.FAILED;
                result.StatusCode = HttpStatusCode.PreconditionFailed;
                result.Data = null;
            }

            return result;
        }

        public BaseViewModel<User> Update(LoginViewModel user)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
