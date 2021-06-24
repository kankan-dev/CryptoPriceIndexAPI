using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPriceIndexAPI.Models
{
    public partial class BitCoinPriceIndex
    {
        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("bpi")]
        public Dictionary<string, Bpi> Bpi { get; set; }
    }

    public partial class Bpi
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate_float")]
        public double RateFloat { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("updatedISOAt")]
        public DateTimeOffset UpdatedIsoAt { get; set; }

        [JsonProperty("updateduk")]
        public string Updateduk { get; set; }
    }

}
