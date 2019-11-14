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
        public enum StatusProject
        {
            Started = 0,
            Paused = 1,
            Canceled = 2,
            Closed = 3
        }

    }
}
