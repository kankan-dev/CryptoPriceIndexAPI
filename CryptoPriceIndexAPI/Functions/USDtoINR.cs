using CryptoPriceIndexAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoPriceIndexAPI.Functions
{
    public class USDtoINR
    {
        public async Task<double> Coverter()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice/inr.json";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BitCoinPriceIndex>(json);
                double INR = result.Bpi["INR"].RateFloat;
                double USD = result.Bpi["USD"].RateFloat;
                return INR / USD;
            }
            else
            {
                return 0;
            }
        }
    }
}
