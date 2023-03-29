using Business.Services.Abstract;
using Core.Utilities.Results;
using DataAccess.Services.Abstract;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ILogger<CurrencyManager> _logger;
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal, ILogger<CurrencyManager> logger)
        {
            _currencyDal = currencyDal;
            _logger = logger;
        }

        public Result<List<Currency>> GetAllCurrencyBetweenTwoDate(DateTime dateStart,DateTime dateEnd)
        {
            
            try
            {
                var valueResult = _currencyDal.GetAllCurrencyBetweenTwoDate(dateStart, dateEnd);
                _logger.LogInformation(valueResult.Message);
               
                return new Result<List<Currency>>(data: valueResult.Data, message: $"İstenilen tarih aralığındaki kur değerleri başarıyla getirildi. \n Detay:{valueResult.Message}", success:true);
            }

            catch (Exception e)
            {
                _logger.LogError($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}.Failed.{Environment.NewLine}İki tarih arasındaki kur değerleri getirilirken bir hata oluştu. \n Detay:{e.Message}");
              
                return new Result<List<Currency>>(data: null, message:$"İki tarih arasındaki kur değerleri getirilirken bir hata oluştu. \n Detay:{ e.Message }",success:false);
                
            }
            
        }


        public Result<Currency> GetCurrenciesByCode(string code)
        {
            try
            {
                var valueResult = _currencyDal.GetCurrenciesByCode(code);
                _logger.LogInformation(valueResult.Message);
                return new Result<Currency>(data: valueResult.Data, message: $"Belirtilen kur değeri başarıyla getirildi. \n Detay:{valueResult.Message }", success: true);
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Result<Currency>(data: null, message: $"Belirtilen kur değeri getirilirken bir hata oluştu. \n Detay:{e.Message}", success: false);

            }
         
        }


        public Result<List<Currency>> GetCurrenciesBetweenTwoDate(string currencyCode,DateTime dateStart,DateTime dateEnd)
        {
           
            try
            {
                var valueResult = _currencyDal.GetCurrenciesBetweenTwoDate(currencyCode: currencyCode, dateStart: dateStart, dateEnd: dateEnd);
                _logger.LogInformation(valueResult.Message);
                return new Result<List<Currency>>(data: valueResult.Data, message: $"İstenilen tarih aralığındaki belirtilen kur değeri başarıyla getirildi. \n Detay:{valueResult.Message}", success: true);
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Result<List<Currency>>(data: null, message: $"İki tarih arasında belirtilen kur değerleri getirilirken bir hata oluştu. \n Detay:{e.Message}", success: false);

            }
        }
    }
}
