using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Constants
{
    public class Query
    {

        //CURRENCY

        public const string QUERY_GET_CURRENCIES_BY_CODE = $"Select * From Currencies WHERE CurrencyCode = @currencyCode ORDER BY tcmbCurrencyDate DESC,createdTime DESC";

        public const string QUERY_GET_ALL_CURRENCIES_BETWEEN_TWO_DATE = $"Select * From Currencies WHERE CreatedTime BETWEEN @startDate AND @endDate";

        public const string QUERY_GET_GET_CURRENCIES_BETWEEN_TWO_DATE_WITH_CODE = $"Select * From Currencies WHERE CurrencyCode= @currencyCode AND CreatedTime BETWEEN @startDate AND @endDate ";
    }
}
