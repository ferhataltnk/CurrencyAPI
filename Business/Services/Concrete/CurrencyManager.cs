using Business.Services.Abstract;
using Core.Utilities.Results;
using DataAccess.Services.Abstract;
using Entities;
using Serilog;
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
        private readonly ILogger _logger;
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal, ILogger logger)
        {
            _currencyDal = currencyDal;
            _logger = logger;
        }

        public Result<List<Currency>> GetCurrenciesBetweenDates(DateTime dateStart,DateTime dateEnd)
        {
            
            try
            {
                var valueResult = _currencyDal.GetCurrenciesBetweenDates(dateStart, dateEnd);
                _logger.Information(valueResult.Message);
               
                return new Result<List<Currency>>(data: valueResult.Data, message: $"İstenilen tarih aralığındaki kur değerleri başarıyla getirildi.{Environment.NewLine}Detay:{valueResult.Message}", success:true);
            }

            catch (Exception ex)
            {
                _logger.Error($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}.Failed.{Environment.NewLine}İki tarih arasındaki kur değerleri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}");
              
                return new Result<List<Currency>>(data: null, message:$"İki tarih arasındaki kur değerleri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ ex.Message }",success:false);
                
            }
            
        }


        public Result<Currency> GetCurrenciesByCode(string currencyCode)
        {
            try
            {
                var valueResult = _currencyDal.GetCurrenciesByCode(currencyCode);
                _logger.Information(valueResult.Message);
                return new Result<Currency>(data: valueResult.Data, message: $"Belirtilen kur değeri başarıyla getirildi.{Environment.NewLine}Detay:{valueResult.Message }", success: true);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new Result<Currency>(data: null, message: $"Belirtilen kur değeri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}", success: false);

            }
         
        }


        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(string currencyCode,DateTime dateStart,DateTime dateEnd)
        {
           
            try
            {
                var valueResult = _currencyDal.GetCurrenciesByCodeAndBetweenDates(currencyCode: currencyCode, dateStart: dateStart, dateEnd: dateEnd);
                _logger.Information(valueResult.Message);
                return new Result<List<Currency>>(data: valueResult.Data, message: $"İstenilen tarih aralığındaki belirtilen kur değeri başarıyla getirildi.{Environment.NewLine}Detay:{valueResult.Message}", success: true);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new Result<List<Currency>>(data: null, message: $"İki tarih arasında belirtilen kur değerleri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}", success: false);

            }
        }
    }
}
