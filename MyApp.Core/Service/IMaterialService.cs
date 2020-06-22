using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Service
{
    public interface IMaterialService
    {
        void create(List<MaterialViewPage> request);
    }
}
