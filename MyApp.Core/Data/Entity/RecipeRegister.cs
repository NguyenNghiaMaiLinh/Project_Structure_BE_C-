using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Core.Data.Entity
{
    public partial class RecipeRegister:BaseEntity
    {

        [StringLength(50)]
        public string RecipeId { get; set; }
        [StringLength(50)]
        public string Saver { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }
        public bool? Done { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("RecipeRegister")]
        public virtual Recipe Recipe { get; set; }
    }
}
