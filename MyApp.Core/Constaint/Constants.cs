namespace MyApp.Core.Constaint
{
    public class Constants
    {
        public const string USER_ANONYMOUS = "anonymous";
        public const string CLAIM_USERNAME = "username";
        public const int MAX_PAGE_SIZE = 50;
        public const int DEFAULT_PAGE_SIZE = 10;
        public const int DEFAULT_PAGE_INDEX = 1;

    }
    public static class Role
    {
        public const string Admin = "admin";
        public const string User = "user";
    }
    public class ErrMessageConstants
    {

        public const string INVALID_ACCOUNT = "Invalid_Username_Or_Password";
        public const string NOTFOUND = "Not_Found";
        public const string INVALID_PERMISSION = "Invalid_Permission";
        public const string ACCOUNT_ALREADY_EXISTS = "Account_Already_Exists";

    }
    public class MessageConstants
    {
        public const string SUCCESS = "Success";
        public const string NO_RECORD = "No_Record";
        public const string FAILURE = "Failure";
        public const string NOTFOUND = "Not_Found";
    }
}
