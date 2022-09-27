
using forexapi.Context;
//using forexapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForexApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ForexDbContext _context;
        public CurrenciesController(ForexDbContext context)
        {
            _context = context;
        }

        // GET: api/<CurrenciesController>
        [HttpGet]
        public IEnumerable<CurrencyRate> Get()
        {
            var currencyList = (IEnumerable<CurrencyRate>)_context.CurrencyRates.ToList();
                     
            return currencyList;
        }

        // GET: api/<CurrencyRateController>
        [HttpGet]
        public string GetRate(string senderAmmount, string fCurrency, string tCurrency)
        {
            var rate = (CurrencyRate)_context.CurrencyRates.
                Where(x => x.CurrencyFrom == fCurrency && x.CurrencyTo == tCurrency).FirstOrDefault();
            
            if (rate.Rate!=0)
            {
                var reciverAmount = decimal.Parse(senderAmmount) / rate.Rate;               
                
                string json1 = JsonConvert.SerializeObject(new
                { rate = rate.Rate, reciverAmount = reciverAmount });
                return json1;
            }
            return JsonConvert.SerializeObject(new{ rate = 0, reciverAmount = 0 });
        }
        // POST api/<CurrenciesController>
        [HttpPost]
        public string Post([FromBody] CurrencyRate currencyRate)
        {
            if (currencyRate != null)
            {
                //var currencyList = (IEnumerable<CurrencyRate>)_context.CurrencyRates.ToList();
                //currencyRate.Id = currencyList.Count() + 1;
                _context.CurrencyRates.Add(currencyRate);
                _context.SaveChanges();
            }
            return "CurrencyRates successfully";
        }
       //Delete api/<CurrenciesController
       [HttpDelete]
        //public async Task<IActionResult>
        public bool Delete(int id)
        {
            var result = _context.CurrencyRates.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                //result.isDeleted = true;
                _context.CurrencyRates.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
