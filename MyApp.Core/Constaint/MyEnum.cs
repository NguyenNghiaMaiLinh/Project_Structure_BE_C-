using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyApp.Core.Constaint
{
    public class MyEnum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ErrorCode
        {
            UnknownError = -99,
            EntityNotFound = -1,
            BadRequest = -2,
            IncorrectUsername = -3,
            IncorrectPassword = -4,
            UserLockedOut = -5,
            AccessDenied = -6,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Gender
        {
            //"Nam"
            Male = 0,
            //"Nữ"
            Female = 1,
            //"Thứ ba"
            Unknown = 2
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Order
        {
            Asc = 0,
            Desc = 1,
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderStatus
        {
            Submitted = 0,
            Delivered = 1,
            Canceled = 2,
            Delivering = 3,
        }
    }
}
