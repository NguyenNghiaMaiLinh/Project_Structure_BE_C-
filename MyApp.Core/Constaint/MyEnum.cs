﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyApp.Core.Constaint
{
    public class MyEnum
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProcessingOfWorkflow
        {
            None = 0,
            Started = 1,
            Paused = 2,
            Canceled = 3
        }

    }
}
