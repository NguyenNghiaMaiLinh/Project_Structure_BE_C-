using AutoMapper;
using Microsoft.Extensions.Configuration;
using MyApp.Core.Configs;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service.HelperService;
using Newtonsoft.Json;
using StackExchange.Redis;
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
        private static readonly string ACCOUNTS = "accounts";

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _mapper = mapper;
        }

        private static Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string connectionString = AppSettings.Configs.GetValue<string>("RedisConnectionString");
            return ConnectionMultiplexer.Connect(connectionString);
        });

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

        public BaseViewModel<UserViewModel> GetInformation()
        {
            IDatabase cache = LazyConnection.Value.GetDatabase();

            string accounts = cache.StringGet(ACCOUNTS);
            var list = JsonConvert.DeserializeObject<List<Account>>(accounts);
            var entity = list.FirstOrDefault(a => a.Username == _repository.GetUsername());
            if (entity == null)
            {
                entity = _repository.GetById(_repository.GetUsername());
            }
            else if (entity == null)
            {
                return new BaseViewModel<UserViewModel>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };
            }

            return new BaseViewModel<UserViewModel>
            {
                StatusCode = HttpStatusCode.OK,
                Description = null,
                Code = MessageConstants.SUCCESS,
                Data = _mapper.Map<UserViewModel>(entity)
            };
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
            entity.DeviceToken = user.DeviceToken;
            _repository.Update(entity);
            Save();
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
                entity = _mapper.Map<Account>(user);
                entity.Role = Role.User;
                entity.IsDelete = false;
                _repository.Add(entity);
                Save();
                return new BaseViewModel<Account>
                {
                    StatusCode = HttpStatusCode.Created,
                    Data = _mapper.Map<Account>(entity)
                };

            }
            entity.DeviceToken = user.DeviceToken;
            entity.FullName = user.FullName;
            entity.AvatarPath = user.AvatarPath;
            entity.Email = user.Email;
            _repository.Update(entity);
            Save();

            return new BaseViewModel<Account>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<Account>(entity)
            };
        }

        public BaseViewModel<Account> Register(RegisterViewModel user)
        {
            IDatabase cache = LazyConnection.Value.GetDatabase();
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
                AvatarPath = user.AvatarPath
            };
            var temp = new SaltHashPassword(user.Password);
            entity.SaltPassword = temp.Salt;
            entity.HashPassword = temp.Hash;
            entity.Role = Role.User;
            entity.IsDelete = false;
            entity.DeviceToken = user.DeviceToken;

            _repository.Add(entity);
            Save();
            var list = new List<Account>();
            list = _repository.GetMany(a => a.IsDelete == false).ToList();
            var json = JsonConvert.SerializeObject(list);
            cache.StringSet(ACCOUNTS, json);

            result.Code = MessageConstants.SUCCESS;
            result.Description = null;
            result.StatusCode = HttpStatusCode.Created;
            result.Data = _mapper.Map<Account>(entity);
            return result;
        }

        public BaseViewModel<UserViewPage> Update(UserUpdateViewPage user)
        {
            IDatabase cache = LazyConnection.Value.GetDatabase();
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
            entity.DeviceToken = user.DeviceToken;
            _repository.Update(entity);
            Save();

            var list = new List<Account>();
            list = _repository.GetMany(a => a.IsDelete == false).ToList();
            var json = JsonConvert.SerializeObject(list);
            cache.StringSet(ACCOUNTS, json);

            result.Data = _mapper.Map<UserViewPage>(entity);

            return result;
        }

        private static ConnectionMultiplexer ConnectionRedis
        {
            get
            {
                return LazyConnection.Value;
            }
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }

        public BaseViewModel<IEnumerable<UserViewModel>> SeachAccount(string userId)
        {
            IDatabase cache = LazyConnection.Value.GetDatabase();

            string accounts = cache.StringGet(ACCOUNTS);
            var list = JsonConvert.DeserializeObject<List<Account>>(accounts);
            var entity = list.Where(a => a.Username.Contains(userId)).ToList();
            if (entity == null)
            {
                entity = _repository.searchUser(userId).ToList();
            }
            else if (entity == null)
            {
                return new BaseViewModel<IEnumerable<UserViewModel>>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND,
                    Data = null
                };
            }

            return new BaseViewModel<IEnumerable<UserViewModel>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<IEnumerable<UserViewModel>>(entity)
            };
        }
    }
}
