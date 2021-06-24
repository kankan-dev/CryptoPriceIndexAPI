using CryptoPriceIndexAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoPriceIndexAPI.Functions
{
    public class GetBTCRate
    {
        public async Task<double> CurrentBTC()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice/inr.json";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BitCoinPriceIndex>(json);
                
                return result.Bpi["INR"].RateFloat;
               
            }
            else
            {
                return 0;
            }
        }
        public async Task<double> YesterdayBTC()
        {
            DateTime today = DateTime.Now;
            string Today = today.ToString("yyyy'-'MM'-'dd");
            DateTime yesterday = DateTime.Now.AddDays(-1);
            string Yesterday = yesterday.ToString("yyyy'-'MM'-'dd");

            string url = "https://api.coindesk.com/v1/bpi/historical/close.json?start=" + Yesterday + "&end=" + Today;
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ChangeCD>(json);

                USDtoINR obj = new USDtoINR();
                double BuyRate = obj.Coverter().Result; //returns 1 USD in Rupees
                double usd = result.Bpi.YesterdayRate;
                double res = usd * BuyRate;
                return res;
            }
            else
            {
                return 0;
            }
        }
    }
}
