using CustInformation_WebBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustInformation_WebBlazor.Data
{
    public class SearchServices
    {
        
        public SearchServices() 
        {

        }
        public async Task<List<CustomerDetailViewModel>> Search()
        {
            var resultedViewModel = new List<CustomerDetailViewModel>();
            resultedViewModel = new CustListPurchasesService().WebApiSearch();
            
            return resultedViewModel;
        }
        public async Task<List<CustomerDetailViewModel>> SearchMonth()
        {
            var resultedViewModel = new List<CustomerDetailViewModel>();
            resultedViewModel = new CustListPurchasesPerMonthService().WebApiSearch();

            return resultedViewModel;
        }
    }
}
