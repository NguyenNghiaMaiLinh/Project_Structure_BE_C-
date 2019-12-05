using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyApp.Core.Constaint
{
    public class MyEnum
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Status
        {
            Doing = 0,
            Finish = 1,
        }
    }
}
