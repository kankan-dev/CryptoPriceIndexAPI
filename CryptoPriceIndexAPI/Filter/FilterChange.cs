using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CryptoPriceIndexAPI.Filter
{
    public class FilterChange
    {
        [JsonProperty("value")]
        public string Base { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("BTC_Rate_Now")]
        public double RateNow { get; set; }

        [JsonProperty("BTC_Rate_Yesterday")]
        public double RateYesterday { get; set; }

        [JsonProperty("PercentageChange")]
        public string ChangePercentage { get; set; }
    }
}
