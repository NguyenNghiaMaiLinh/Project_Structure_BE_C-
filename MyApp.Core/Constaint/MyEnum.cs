using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyApp.Core.Constaint
{
    public class MyEnum
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public enum TaskProject
        {
            Started = 0,
            Paused = 1,
            Canceled = 2
        }

    }
}
