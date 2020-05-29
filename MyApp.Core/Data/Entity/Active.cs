using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Data.Entity
{
    public partial class Active:BaseEntity
    {
        public string RecipeId { get; set; }
        public string Account { get; set; }
        public bool? Done { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
