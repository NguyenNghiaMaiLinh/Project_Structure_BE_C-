﻿using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Avartar { get; set; }
        public int? Phone { get; set; }
        public bool? IsDelete { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Role { get; set; }
    }
}
