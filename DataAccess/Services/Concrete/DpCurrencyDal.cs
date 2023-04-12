using Core.Utilities.Results;
using Dapper;
using DataAccess.Services.Abstract;
using DataAccess.Services.Constants;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class DpCurrencyDal : ICurrencyDal
    {
        public Result<List<Currency>> GetCurrenciesBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    var currencies = connection.Query<Currency>(
                        sql:Query.QUERY_GET_ALL_CURRENCIES_BETWEEN_TWO_DATE,
                        param: new {
                                        startDate = new DbString
                                        {
                                            Value = dateStart.ToString("yyyy-MM-dd HH:mm:ss"),
                                            IsAnsi = true,
                                            Length = 20
                                        },
                                        endDate = new DbString
                                        {
                                            Value = dateEnd.ToString("yyyy-MM-dd HH:mm:ss"),
                                            IsAnsi = true,
                                            Length = 20
                                        }
                                    });

                    connection.Close();

                    return new Result<List<Currency>>(data:currencies.ToList(), message: "İki tarih arasındaki kur değerleri başarıyla getirildi.",success: true);
                }
            }
            catch (Exception ex)
            {
                return new Result<List<Currency>>(data: null,message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}",success: false);
            }
        }

        public Result<Currency> GetCurrenciesByCode(string code)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    var currency = connection.QueryFirst<Currency>(Query.QUERY_GET_CURRENCIES_BY_CODE,param: new { currencyCode = new DbString{ Value = code.ToString().Trim()}});
                    connection.Close();

                    return new Result<Currency>(data: currency,message: "Kur değeri başarıyla getirildi.",success: true);
                }
            }
            catch (Exception ex)
            {
                return new Result<Currency>(data: null,message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}",success: false);
            }
        }

        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(string currencyCode, DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    var currencies = connection.Query<Currency>(
                        sql:Query.QUERY_GET_GET_CURRENCIES_BETWEEN_TWO_DATE_WITH_CODE,
                        param: new{
                                      startDate = new DbString { 
                                            Value = dateStart.ToString("yyyy-MM-dd HH:mm:ss"),
                                            IsAnsi = true,
                                            Length = 20 },
                                      endDate = new DbString{ 
                                            Value = dateEnd.ToString("yyyy-MM-dd HH:mm:ss"),
                                            IsAnsi = true,
                                            Length=20 },
                                      currencyCode = new DbString { 
                                            Value = currencyCode.ToString(), 
                                            IsAnsi = true,
                                            Length = 10 }
                                    });

                    connection.Close();
                    return new Result<List<Currency>>(data: currencies.ToList(),message: "İki tarih arasındaki kur değerleri başarıyla getirildi.",success: true);
                }

            }
            catch (Exception ex)
            {
                return new Result<List<Currency>>(data: null,message: $"Beklenmedik bir hata oluştu.{Environment.NewLine}Detay: {ex.Message}",success: false);
            }
        }
    }
}
