namespace DataAccess.Services.Constants
{
    public class Query
    {

        //CURRENCY

        public const string QUERY_GET_CURRENCIES_BY_CODE = @"
        SELECT TOP 1 * 
        FROM Currencies 
        WHERE CurrencyCode = @currencyCode 
        ORDER BY tcmbCurrencyDate DESC,
                 createdTime DESC
        ";

        public const string QUERY_GET_ALL_CURRENCIES_BETWEEN_TWO_DATE = @"
        SELECT * 
        FROM Currencies 
        WHERE CreatedTime 
        BETWEEN @startDate AND @endDate
        ";

        public const string QUERY_GET_GET_CURRENCIES_BETWEEN_TWO_DATE_WITH_CODE = @"
        SELECT * 
        FROM Currencies 
        WHERE CurrencyCode= @currencyCode 
        AND CreatedTime 
        BETWEEN @startDate AND @endDate
        ";
    }
}
