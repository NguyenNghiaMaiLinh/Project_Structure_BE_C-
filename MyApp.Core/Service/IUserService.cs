using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections;
using System.Collections.Generic;

namespace MyApp.Core.Service
{
    public interface IUserService
    {
        BaseViewModel<PagingResult<UserViewPage>> GetAllUser(BasePagingRequestViewModel request);
        BaseViewModel<UserViewModel> GetInformation();
        BaseViewModel<Account> Register(RegisterViewModel user);
        BaseViewModel<IEnumerable<UserViewModel>> SeachAccount(string search);
        BaseViewModel<Account> Login(LoginViewModel user);
        BaseViewModel<Account> LoginByFacebook(LoginFacebookViewModel user);
        BaseViewModel<UserViewPage> Update(UserUpdateViewPage user);
        BaseViewModel<bool> DeleteAccount(string id);
    }
}
