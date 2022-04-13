using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppMitAlles
{
    class dateJson
    {
        public class DateJson
        {
            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("milliseconds_since_epoch")]
            public string Milliseconds_since_epoch { get; set; }

            [JsonProperty("time")]
            public string Time { get; set; }

        }
    }
}
