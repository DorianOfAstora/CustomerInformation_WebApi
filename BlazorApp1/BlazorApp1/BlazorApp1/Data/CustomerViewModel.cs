namespace BlazorApp1.Data
{
    public class CustomerSearchViewModel
    {
        public string customer { get; set; }
        public string item { get; set; }
        
    }
    public class CustomerResultViewModel
    {
        public string date { get; set; }
        public int total { get; set; }
        public List<string> cust { get; set; }
    }
    public class CustomerDetailViewModel
    {
        public string item { get; set; }
        public List<CustomerResultViewModel> detail { get; set; }
    }

}
