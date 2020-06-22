using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Service
{
    public interface IStepService
    {
        void create(List<StepViewPage> request);
    }
}
