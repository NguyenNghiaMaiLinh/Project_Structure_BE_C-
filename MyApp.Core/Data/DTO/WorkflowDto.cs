using MyApp.Core.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Core.Data.DTO
{
    public class WorkflowDto :BaseEntity
    {
        [Column("Workflow_Main_Id")]
        public string WorkflowMainId { get; set; }
        [Column("Workflow_Name")]
        public string WorkflowName { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }
        [Column("Is_Main")]
        public bool? IsMain { get; set; }
        [Column("Total_Task")]
        public int? TotalTask { get; set; }
        [Column("Done_Task")]
        public int? DoneTask { get; set; }

    }
}
