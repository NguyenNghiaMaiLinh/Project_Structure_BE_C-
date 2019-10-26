using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Configs
{
    public class CorsSettings
    {
        public string AllowOrigin { get; set; }
        public string AllowMethod { get; set; }
        public string AllowHeader { get; set; }
    }
}
