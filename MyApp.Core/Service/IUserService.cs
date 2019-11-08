﻿using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
   public interface IUserService
    {
        BaseViewModel<PagingResult<UserViewPage>> GetAllUser(BasePagingRequestViewModel request);
        BaseViewModel<User> Register(RegisterViewModel user);
        BaseViewModel<User> Login(LoginViewModel user);
        BaseViewModel<User> Update(LoginViewModel user);
        BaseViewModel<UserViewPage> RegisterStaff(RegisterViewModel user);
        BaseViewModel<UserViewPage> RegisterAdmin(RegisterViewModel user);
        BaseViewModel<bool> DeleteAccount(UserDeleteViewPage user);
    }
}
