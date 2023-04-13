using Core.Utilities.Results;
using Entities;

namespace DataAccess.Services.Abstract
{
    public interface ICurrencyDal
    {
        public Result<List<Currency>> GetCurrenciesByCode(CurrencyRequestModel currencyRequestModel);
        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(CurrencyRequestModel currencyRequestModel);
        public Result<List<Currency>> GetCurrenciesBetweenDates(CurrencyRequestModel currencyRequestModel);


    }
}
