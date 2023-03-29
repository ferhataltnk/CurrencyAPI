using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Abstract
{
    public interface ICurrencyDal
    {
        public Result<Currency> GetCurrenciesByCode(string code);
        public Result<List<Currency>> GetCurrenciesBetweenTwoDate(string currencyCode,DateTime dateStart,DateTime dateEnd);
        public Result<List<Currency>> GetAllCurrencyBetweenTwoDate(DateTime dateStart,DateTime dateEnd);


    }
}
