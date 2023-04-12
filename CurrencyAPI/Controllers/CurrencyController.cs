using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("v1/api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
       
        [HttpGet("{currencyCode}")]
        public IActionResult Currency(string currencyCode)
        {   
                var valueResult = _currencyService.GetCurrenciesByCode(currencyCode);
                return valueResult.Success? Ok(valueResult):BadRequest(valueResult);
        }


        [HttpGet("{dateStart}&{dateEnd}")]
        public IActionResult Currency(DateTime dateStart, DateTime dateEnd)
        {
                var valueResult = _currencyService.GetCurrenciesBetweenDates(dateStart, dateEnd);
            
                return valueResult.Success?Ok(valueResult):BadRequest(valueResult);   
        }

       
        [HttpGet("{currencyCode}/{dateStart}&{dateEnd}")]
        public IActionResult Currency(string currencyCode, DateTime dateStart, DateTime dateEnd)
        {
            var valuesResult = _currencyService.GetCurrenciesByCodeAndBetweenDates(currencyCode:currencyCode,dateStart:dateStart,dateEnd: dateEnd);

            return valuesResult.Success ? Ok(valuesResult) : BadRequest(valuesResult);

        }
    }
}
