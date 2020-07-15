using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp_API.Models
{
    public partial class RecipeRegister
    {
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string RecipeId { get; set; }
        [StringLength(50)]
        public string Saver { get; set; }
        [Column("Create_At")]
        [StringLength(10)]
        public string CreateAt { get; set; }
        [Column("Create_By")]
        [StringLength(10)]
        public string CreateBy { get; set; }
        [Column("Update_At")]
        [StringLength(10)]
        public string UpdateAt { get; set; }
        [Column("Update_By")]
        [StringLength(10)]
        public string UpdateBy { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }
        public bool? Done { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("RecipeRegister")]
        public virtual Recipe Recipe { get; set; }
    }
}
