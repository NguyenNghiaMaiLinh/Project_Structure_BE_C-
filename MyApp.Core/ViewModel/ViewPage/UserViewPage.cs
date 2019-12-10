namespace MyApp.Core.ViewModel.ViewPage
{
    public class UserViewPage
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public string Email { get; set; }
        public string DeviceToken { get; set; }
    }
    public class UserUpdateViewPage
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public string Email { get; set; }
        public string DeviceToken { get; set; }
    }
    public class UserCreateViewPage
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DeviceToken { get; set; }

    }
    public class UserDeleteViewPage
    {
        public string Id { get; set; }
    }
}
