using MyApp.Core.Data.Entity;
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
        BaseViewModel<Account> Register(RegisterViewModel user);
        BaseViewModel<Account> Login(LoginViewModel user);
        BaseViewModel<UserViewPage> Update(string userId, UserUpdateViewPage user);
        BaseViewModel<bool> DeleteAccount(string id);
    }
}
