using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        [HttpGet("v1/currency/{code}")]
        public IActionResult Currency(string code)
        {   
                var valueResult = _currencyService.GetCurrenciesByCode(code);
                return valueResult.Success? Ok(valueResult.Data):BadRequest(valueResult.Message);
        }


        [HttpGet("v1/currency/{dateStart}&{dateEnd}")]
        public IActionResult Currency(DateTime dateStart, DateTime dateEnd)
        {
                var valueResult = _currencyService.GetAllCurrencyBetweenTwoDate(dateStart, dateEnd);

                return valueResult.Success?Ok(valueResult.Data):BadRequest(valueResult.Message);   
        }


        [HttpGet("v1/currency/{currencyCode}/{dateStart}&{dateEnd}")]
        public IActionResult Currency(string currencyCode, DateTime dateStart, DateTime dateEnd)
        {
            var valuesResult = _currencyService.GetCurrenciesBetweenTwoDate(currencyCode:currencyCode,dateStart:dateStart,dateEnd: dateEnd);

            return valuesResult.Success ? Ok(valuesResult.Data) : BadRequest(valuesResult.Message);

        }
    }
}
