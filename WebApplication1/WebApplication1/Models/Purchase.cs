using System;
using System.Collections.Generic;
using System.Text;

namespace fbk_api.Models
{
	
  public class Purchase
  {
    public string date { get; set; }
    public string item { get; set; }
    public string cust { get; set; }
  }

  public class ViewPurchasedetail{
        public string date { get; set; }
        public int total { get; set; }
        public List<string> cust { get; set; }
    }
    public class ViewPurchase
    {
        public string item { get; set; }
        public List<ViewPurchasedetail> detail { get; set; }
        
    }


}