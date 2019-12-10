﻿using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public interface IWorkflowService
    {
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflow(BasePagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflowByStatus(BasePagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflowByHistory(BasePagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflowByCreator(BasePagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflowByWorkflowId(TaskPagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getAllWorkflowByAdmin(BasePagingRequestViewModel request);
        BaseViewModel<PagingResult<WorkflowViewPage>> getWorkflowUserByAdmin(WorkflowAdminRequestViewModel request);
        BaseViewModel<WorkflowViewPage> changeStatus(string id, WorkflowChangeStatusViewPage request);
        BaseViewModel<WorkflowViewPage> getWorkflowById(string id);
        BaseViewModel<WorkflowViewPage> createInstance(WorkflowCreateInstanceViewPage request);
        BaseViewModel<WorkflowViewPage> create(WorkflowCreateViewPage request);
        BaseViewModel<WorkflowViewPage> update(WorkflowUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
