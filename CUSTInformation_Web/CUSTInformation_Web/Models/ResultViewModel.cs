namespace CUSTInformation_Web.Models
{
    public class ResultViewModel
    {
        public string ItemNumber { get; set; }
        public int UniqueCustomers { get; set; }
        public List<string> CustomerList = new List<string>();
    }
}
