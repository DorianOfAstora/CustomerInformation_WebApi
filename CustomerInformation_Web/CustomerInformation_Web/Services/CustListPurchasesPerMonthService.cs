using CustomerInformation_Web.Data;
using Newtonsoft.Json;

namespace CustomerInformation_Web.Services
{
    public class CustListPurchasesPerMonthService : CustAbstract
    {
        private static Uri Baseurl = new Uri("https://localhost:7190");
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// Il metodo estende la classe astratta che si occupa del richiamo delle web api di customer information
        /// </summary>
        /// <returns></returns>
        public override List<CustomerDetailViewModel> WebApiSearch()
        {
            try
            {
                var resModel = new List<CustomerDetailViewModel>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = Baseurl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = client.GetAsync(Baseurl + "api/purchases/listbymonth").GetAwaiter().GetResult();
                    var returnedJson = response.Content.ReadAsStringAsync().Result;
                    var retArray = JsonConvert.DeserializeObject<CustomerDetailViewModel[]>(returnedJson).ToList();
                    resModel = retArray;
                }

                return resModel;
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
