using Business.Services.Abstract;
using Entities;
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


        [HttpGet]
        public IActionResult Get(CurrencyRequestModel currencyRequestModel)
        {
            var valueResult = _currencyService.GetAsync(currencyRequestModel);
            return valueResult.Result.Success ? Ok(valueResult) : BadRequest(valueResult.Result.Message);
        }

    }
}
