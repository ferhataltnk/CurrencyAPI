using Business.Services.Abstract;
using Core.Utilities.Results;
using DataAccess.Services.Abstract;
using Entities;
using Serilog;
using System.Reflection;

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

        public async Task<Result<List<Currency>>> GetAsync(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                #region Validation Control





                #endregion

                if (currencyRequestModel.CurrencyCode != null && currencyRequestModel.StartDate == null && currencyRequestModel.EndDate == null)
                    return await GetCurrenciesByCodeAsync(currencyRequestModel);
                else if (currencyRequestModel.StartDate != null && currencyRequestModel.EndDate != null && currencyRequestModel.CurrencyCode == null)
                    return await GetCurrenciesBetweenDatesAsync(currencyRequestModel);
                else if (currencyRequestModel.StartDate != null && currencyRequestModel.EndDate != null && currencyRequestModel.CurrencyCode != null)
                    return await GetCurrenciesByCodeAndBetweenDatesAsync(currencyRequestModel);
                else
                    return new Result<List<Currency>>(success: false, data: null, message: $"Kriterlerinize uygun kayıt bulunamamıştır.");
            }

            catch (Exception exception)
            {
                _logger.Error($"{GetType().FullName}.{nameof(GetAsync)} Get Error Message: {exception.Message}");
                return new Result<List<Currency>>(success: false, data: null, message: $"Servise istek atılırken bir hata oluştu.");
            }
        }



        private async Task<Result<List<Currency>>> GetCurrenciesBetweenDatesAsync(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                var valueResult = _currencyDal.GetCurrenciesBetweenDates(currencyRequestModel);
                _logger.Information(valueResult.Message);

                return new Result<List<Currency>>(data: valueResult.Data, message: valueResult.Data.Count() > 0 ? $"İstenilen tarih aralığındaki kur değerleri başarıyla getirildi.{Environment.NewLine}Detay:{valueResult.Message}" : "İçerik bulunamadı", success: true);
            }

            catch (Exception ex)
            {
                _logger.Error($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}.Failed.{Environment.NewLine}İki tarih arasındaki kur değerleri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}");

                return new Result<List<Currency>>(data: null, message: $"İki tarih arasındaki kur değerleri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}", success: false);
            }
        }
        private async Task<Result<List<Currency>>> GetCurrenciesByCodeAsync(CurrencyRequestModel currencyRequestModel)
        {
            try
            {
                var valueResult = _currencyDal.GetCurrenciesByCode(currencyRequestModel);
                _logger.Information(valueResult.Message);
                return new Result<List<Currency>>(data: valueResult.Data, message: valueResult.Data is not null ? $"Belirtilen kur değeri başarıyla getirildi.{Environment.NewLine}Detay:{valueResult.Message}" : valueResult.Message, success: valueResult.Data is not null ? true : false);
            }
            catch (Exception ex)
            {
                _logger.Error($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}.Failed.{Environment.NewLine}Kur değeri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}");

                return new Result<List<Currency>>(data: null, message: $"Kur değeri getirilirken bir hata oluştu.{Environment.NewLine}Detay:{ex.Message}", success: false);

            }

        }
        private async Task<Result<List<Currency>>> GetCurrenciesByCodeAndBetweenDatesAsync(CurrencyRequestModel currencyRequestModel)
        {

            try
            {
                var valueResult = _currencyDal.GetCurrenciesByCodeAndBetweenDates(currencyRequestModel);
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
