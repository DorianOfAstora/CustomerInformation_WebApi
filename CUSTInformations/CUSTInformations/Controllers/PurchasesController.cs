using CUSTInformations.CustomerFileUnpackager;
using CUSTInformations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CUSTInformations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        [HttpGet("GetPurchaseFileRecords")]
        public IActionResult GetPurchaseFileRecords()
        {
            try
            {
                var purchases = new CustUnpackagerUtility().ReadPurchases();
                var result = new List<object>();
                var purchaseInfos = new Dictionary<string, List<string>>();

                foreach (var purchase in purchases)
                {
                    foreach (var item in purchase.purchasedItems)
                    {
                        if (!purchaseInfos.ContainsKey(item))
                        {
                            purchaseInfos[item] = new List<string>();
                        }

                        if (!purchaseInfos[item].Contains(purchase.customerNumber))
                        {
                            purchaseInfos[item].Add(purchase.customerNumber);
                        }
                    }
                }



                foreach (var item in purchaseInfos)
                {
                    result.Add(new
                    {
                        ItemNumber = item.Key,
                        UniqueCustomers = item.Value.Count,
                        CustomerList = item.Value
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet("GetPurchasesPerMonths")]
        public IActionResult GetPurchasesPerMonths()
        {
            var result = new List<object>();
            var purchaseInfos = new Dictionary<string, List<string>>();
            var customerPerMonth = new CustUnpackagerUtility().ReadPurchasesPerMonths();
            foreach (var cust in customerPerMonth.distinctCustomers)
            {
                result.Add(new { customerPerMonth = cust });
            }
            return Ok(result);
        }
    }
}
