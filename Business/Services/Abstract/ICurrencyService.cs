using Core.Utilities.Results;
using Entities;

namespace Business.Services.Abstract
{
    public interface ICurrencyService
    {
        public Task<Result<List<Currency>>> GetAsync(CurrencyRequestModel currencyRequestModel);

        //validation => FleuntValidation

    }
}
