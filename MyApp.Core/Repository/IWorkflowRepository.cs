﻿using MyApp.Core.Data.DTO;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IWorkflowRepository : IRepository<Workflow>
    {
        IEnumerable<WorkflowDto> GetAllWorkflow(int? pageIndex, int? pageSize, string userId, string search);
        IEnumerable<WorkflowDto> GetAllWorkflowByStatus(int? pageIndex, int? pageSize, string userId, string search);
        IEnumerable<WorkflowDto> GetAllWorkflowByHistory(int? pageIndex, int? pageSize, string userId, string search);
        IEnumerable<Workflow> GetAllWorkflowByCreator(int? pageIndex, int? pageSize, string userId, string search);
        IEnumerable<Workflow> GetAllWorkflowByWorkflowId(int? pageIndex, int? pageSize, string workflowId, string search);
    }
}
