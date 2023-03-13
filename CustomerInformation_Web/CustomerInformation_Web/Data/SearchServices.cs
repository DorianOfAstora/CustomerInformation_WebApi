using CustomerInformation_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerInformation_Web.Data
{
    public class SearchServices
    {

        public SearchServices()
        {

        }
        /// <summary>
        /// Il metodo si occupa della chiamata al service per il richiamo della web api di ricerca per i customer
        /// </summary>
        /// <returns>In caso di esito positivo ritorna la ricerca tramite web api. In caso di errore riporta il dettaglio dell'errore</returns>
        public async Task<List<CustomerDetailViewModel>> Search()
        {
            try
            {
                var resultedViewModel = new List<CustomerDetailViewModel>();
                resultedViewModel = new CustListPurchasesService().WebApiSearch();

                return resultedViewModel;
            }
            catch (Exception ex)
            {
                CustomerDetailViewModel custErrorViewModel = new CustomerDetailViewModel()
                {
                    error = ErrorHandler.Errors(ex.Message, ex.InnerException.ToString())
                };
                List<CustomerDetailViewModel> errResult = new List<CustomerDetailViewModel>();
                errResult.Add(custErrorViewModel);
                return errResult;
            }
        }
        /// <summary>
        /// Il metodo si occupa della chiamata al service per il richiamo della web api di ricerca per i customer raggruppati per mese
        /// </summary>
        /// <returns>In caso di esito positivo ritorna la ricerca tramite web api. In caso di errore riporta il dettaglio dell'errore</returns>
        public async Task<List<CustomerDetailViewModel>> SearchMonth()
        {
            try
            {
                var resultedViewModel = new List<CustomerDetailViewModel>();
                resultedViewModel = new CustListPurchasesPerMonthService().WebApiSearch();

                return resultedViewModel;
            }
            catch (Exception ex)
            {
                CustomerDetailViewModel custErrorViewModel = new CustomerDetailViewModel()
                {
                    error = ErrorHandler.Errors(ex.Message, ex.InnerException.ToString())
                };
                List<CustomerDetailViewModel> errResult = new List<CustomerDetailViewModel>();
                errResult.Add(custErrorViewModel);
                return errResult;
            }
        }
    }
}
