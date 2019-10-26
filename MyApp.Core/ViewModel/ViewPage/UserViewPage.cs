using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public class UserViewPage
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public int? Phone { get; set; }
    }
    public class UserCreateViewPage
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }

        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string Password { get; set; }

    }
}
