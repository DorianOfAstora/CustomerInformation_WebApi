using Microsoft.AspNetCore.Mvc;
using fbk_api.Services;
using fbk_api.Models;

namespace fbk_api.Controllers{

    [Route("api")]
    [ApiController]
    public class PurchaseController: Controller{
        
        private readonly IDataService _dataService;
        public PurchaseController(IDataService dataService){
            _dataService =dataService;
        }

        [HttpGet(template:"purchases/list")]
        public IActionResult List(){
            List<ViewPurchase> _purchases = _dataService.List();
            return Ok(_purchases);
        }

        [HttpGet(template:"purchases/listbymonth")]
        public IActionResult ListByMonth(){
            List<ViewPurchase> _purchases = _dataService.ListByMonth();
            return Ok(_purchases);
        }

        [HttpGet(template:"purchases/data")]
        public IActionResult Data(
            [FromQuery(Name = "custid")] string? custid
        ){
            List<Purchase> _purchases = _dataService.Data(custid);
            return Ok(_purchases);
        }

        
    }
}