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

        public const string INVALID_ACCOUNT = "Tài khoản không đúng";
        public const string NOTFOUND = "Dữ liệu không tìm thấy";
        public const string ACCOUNTNOTFOUND = "Tài khoản không tìm thấy";
        public const string WORKFLOWNOTFOUND = "Quy trình công việc không tìm thấy";
        public const string WORKFLOWEXISTED = "Tài khoản đã tồn tại";
        public const string INVALID_PERMISSION = "Bạn không có quyền truy cập";
        public const string ACCOUNT_ALREADY_EXISTS = "Tài khoản đã tồn tại";

    }
    public class MessageConstants
    {
        public const string SUCCESS = "Success";
        public const string NO_RECORD = "No_Record";
        public const string FAILURE = "Failure";
        public const string NOTFOUND = "Not_Found";
    }
}
