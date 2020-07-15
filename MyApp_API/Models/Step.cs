using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp_API.Models
{
    public partial class Step
    {
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Image1 { get; set; }
        [StringLength(500)]
        public string Image2 { get; set; }
        public bool? IsRepair { get; set; }
        [StringLength(50)]
        public string RecipeId { get; set; }
        [StringLength(500)]
        public string Video { get; set; }
        [Column("Create_At", TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }
        [Column("Create_By")]
        [StringLength(50)]
        public string CreateBy { get; set; }
        [Column("Update_At", TypeName = "datetime")]
        public DateTime? UpdateAt { get; set; }
        [Column("Update_By")]
        [StringLength(50)]
        public string UpdateBy { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("Step")]
        public virtual Recipe Recipe { get; set; }
    }
}
