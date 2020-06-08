using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public  interface IRegisterService
    {
        BaseViewModel<RegisterViewPage> GetInformation();
        BaseViewModel<Register> Register(RegisterViewModel user);
        BaseViewModel<Register> Login(LoginViewModel user);
    }
}
