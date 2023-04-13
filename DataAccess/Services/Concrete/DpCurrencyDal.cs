using Core.Utilities.Results;
using Dapper;
using DataAccess.Services.Abstract;
using DataAccess.Services.Constants;
using Entities;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAccess.Services.Concrete
{
    public class DpCurrencyDal : ICurrencyDal
    {
        public Result<List<Currency>> GetCurrenciesBetweenDates(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                   
                    connection.Open();
                    var currencies = connection.Query<Currency>(
                        sql: Query.QUERY_GET_ALL_CURRENCIES_BETWEEN_TWO_DATE,
                        param: new
                        {                       
                            startDate= currencyRequestModel.StartDate,
                            endDate= currencyRequestModel.EndDate,                    
                        });

                    connection.Close();

                    return new Result<List<Currency>>(data: currencies.ToList(), message: "İki tarih arasındaki kur değerleri başarıyla getirildi.", success: true);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Currency>>(data: null, message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}", success: false);
            }
        }

        public Result<List<Currency>> GetCurrenciesByCode(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                    List<Currency> temp = new List<Currency>();
                    connection.Open();
                    var currency = connection.Query<Currency>(Query.QUERY_GET_CURRENCIES_BY_CODE, param: new { currencyCode = new DbString { Value = currencyRequestModel.CurrencyCode.ToString().Trim() } });
                    temp = currency.ToList();

                    connection.Close();

                    return new Result<List<Currency>>(data: temp, message: "Kur değeri başarıyla getirildi.", success: true);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Currency>>(data: null, message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}", success: false);
            }
        }

        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    var currencies = connection.Query<Currency>(
                        sql: Query.QUERY_GET_GET_CURRENCIES_BETWEEN_TWO_DATE_WITH_CODE,
                        param: new
                        {
                            startDate = currencyRequestModel.StartDate,
                            endDate = currencyRequestModel.EndDate,
                            currencyCode = new DbString
                            {
                                Value = currencyRequestModel.CurrencyCode.ToString(),
                                IsAnsi = true,
                                Length = 10
                            }
                        });

                   
                    connection.Close();
                    return new Result<List<Currency>>(data: currencies.ToList(), message: "İki tarih arasındaki kur değerleri başarıyla getirildi.", success: true);
                }

            }
            catch (Exception ex)
            {
                return new Result<List<Currency>>(data: null, message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}", success: false);
            }
        }
    }
}
