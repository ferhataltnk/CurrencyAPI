using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICurrencyService
    {

        //validation => FleuntValidation
        public Result<Currency> GetCurrenciesByCode(string currencyCode);
        public Result<List<Currency>> GetCurrenciesBetweenDates(DateTime dateStart,DateTime dateEnd);
        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(string currencyCode,DateTime dateStart,DateTime dateEnd);

    }
}
