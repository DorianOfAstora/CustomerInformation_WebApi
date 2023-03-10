using BlazorApp1.Data;
using Newtonsoft.Json;

namespace BlazorApp1.Services
{
    public class CustListPurchasesService : CustAbstract
    {
        private static Uri Baseurl = new Uri("https://localhost:7190");
        private static HttpClient client = new HttpClient();

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
                    response = client.GetAsync(Baseurl + "api/purchases/list").GetAwaiter().GetResult();
                    var returnedJson = response.Content.ReadAsStringAsync().Result;
                    var retArray = JsonConvert.DeserializeObject<CustomerDetailViewModel[]>(returnedJson).ToList();
                    resModel = retArray;
                }

                return resModel;
            }
            catch (Exception ex)
            {
                return new List<CustomerDetailViewModel>();
            }

        }
    }
}
