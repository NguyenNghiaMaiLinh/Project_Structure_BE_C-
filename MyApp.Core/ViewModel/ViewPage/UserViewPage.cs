using MyApp.Core.Constaint;
using System;

namespace MyApp.Core.ViewModel.ViewPage
{
    public class UserViewPage
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public DateTime? Birthday { get; set; }
        public MyEnum.Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class UserUpdateViewPage
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public DateTime? Birthday { get; set; }
        public MyEnum.Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
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
    public class UserDeleteViewPage
    {
        public string Id { get; set; }
    }
}
