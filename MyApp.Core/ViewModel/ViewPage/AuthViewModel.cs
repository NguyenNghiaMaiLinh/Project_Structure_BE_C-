﻿using MyApp.Core.Attribute;
using MyApp.Core.Constaint;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.ViewModel.ViewPage
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    public class LoginFacebookViewModel
    {
        [Required]
        public string Username { get; set; }
        public string Avarter { get; set; }
        [Required]
        public string DeviceToken { get; set; }

    }
    public class TokenViewModel
    {
        public string Roles { get; set; }
        public string Avarter { get; set; }
        public string Fullname { get; set; }
        public string Access_token { get; set; }
        public DateTime Expires_in { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [CheckName(Property = "Fullname")]
        public string Fullname { get; set; }

    }

}