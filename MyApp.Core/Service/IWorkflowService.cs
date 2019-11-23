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
   public interface IWorkflowService
    {
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflow(BasePagingRequestViewModel request);
        BaseViewModel<WorkflowViewPage> getWorkflowById(string id);
        BaseViewModel<WorkflowViewPage> createInstance(WorkflowCreateInstanceViewPage request);
        BaseViewModel<WorkflowViewPage> create(WorkflowCreateViewPage request);
        BaseViewModel<WorkflowViewPage> update( WorkflowUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
