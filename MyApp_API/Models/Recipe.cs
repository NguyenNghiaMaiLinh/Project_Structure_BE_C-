using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp_API.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Material = new HashSet<Material>();
            RecipeRegister = new HashSet<RecipeRegister>();
            Step = new HashSet<Step>();
        }

        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Image { get; set; }
        public int? NumberPeople { get; set; }
        public int? TimeCook { get; set; }
        public int? LevelRecipe { get; set; }
        public int? Liked { get; set; }
        public int? Disliked { get; set; }
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

        [InverseProperty("Recipe")]
        public virtual ICollection<Material> Material { get; set; }
        [InverseProperty("Recipe")]
        public virtual ICollection<RecipeRegister> RecipeRegister { get; set; }
        [InverseProperty("Recipe")]
        public virtual ICollection<Step> Step { get; set; }
    }
}
