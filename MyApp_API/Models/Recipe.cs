using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Active = new HashSet<Active>();
            Material = new HashSet<Material>();
            RecipeRegister = new HashSet<RecipeRegister>();
            Step = new HashSet<Step>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? NumberPeople { get; set; }
        public int? TimeCook { get; set; }
        public int? LevelRecipe { get; set; }
        public int? Liked { get; set; }
        public int? Disliked { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Active> Active { get; set; }
        public virtual ICollection<Material> Material { get; set; }
        public virtual ICollection<RecipeRegister> RecipeRegister { get; set; }
        public virtual ICollection<Step> Step { get; set; }
    }
}
