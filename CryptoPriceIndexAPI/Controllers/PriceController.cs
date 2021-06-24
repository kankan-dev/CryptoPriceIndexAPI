using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoPriceIndexAPI.Models;
using CryptoPriceIndexAPI.Filter;
using CryptoPriceIndexAPI.Functions;

namespace CryptoPriceIndexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        

        [HttpGet]
        [Route("OneDayChange")]
        public async Task<IActionResult> Change()
        {
            try
            {

             GetBTCRate btcrate = new GetBTCRate();

             double CurrentBtcRate = await btcrate.CurrentBTC();

             double YesterdayBtcRate = btcrate.YesterdayBTC().Result;

             double percent = ((CurrentBtcRate - YesterdayBtcRate) / YesterdayBtcRate) * 100;
              
             string percentage = Convert.ToString(Math.Round(percent, 2, MidpointRounding.ToEven));
           
            
             List<FilterChange> TList = new List<FilterChange>();
              TList.Add(new FilterChange()
              {
                    Base = "1 BTC",
                    Currency = "Indian Rupees",
                    RateNow = CurrentBtcRate,
                    RateYesterday = YesterdayBtcRate,
                    ChangePercentage = percentage
              }) ;
                return Ok(TList);

                

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
