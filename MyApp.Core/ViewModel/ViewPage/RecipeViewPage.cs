using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
   public partial class RecipeViewPage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? NumberPeople { get; set; }
        public int? TimeCook { get; set; }
        public int? LevelRecipe { get; set; }
        public int? Liked { get; set; }
        public int? Disliked { get; set; }
        public string CreateBy { get; set; }
    }
    public partial class RecipeCreateViewPage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? TimeCook { get; set; }
        public int? LevelRecipe { get; set; }

    }
    public partial class RecipeUpdateViewPage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? NumberPeople { get; set; }
        public int? TimeCook { get; set; }
        public int? LevelRecipe { get; set; }
        public int? Liked { get; set; }
        public int? Disliked { get; set; }
    }
}
