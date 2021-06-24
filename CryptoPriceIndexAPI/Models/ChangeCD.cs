using Newtonsoft.Json.Converters;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoPriceIndexAPI.Models
{
    public partial class ChangeCD
    {
        [JsonProperty("bpi")]
        public Bpinew Bpi { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }

    public partial class Bpinew
    {
       // public JsonSerializer date = JsonSerializer.Create();
        //public string date = JsonSerializer.Serialize()
        //public void GetObject()
        //{
        //    Json
        //}
        
        [JsonConverter(typeof(DateFormateConverter),"yyyy'-'MM'-'dd")]
        public double YesterdayRate { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("updatedISO")]
        public DateTimeOffset UpdatedIso { get; set; }
    }

    public class DateFormateConverter : IsoDateTimeConverter
    {
        public DateFormateConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
        }
