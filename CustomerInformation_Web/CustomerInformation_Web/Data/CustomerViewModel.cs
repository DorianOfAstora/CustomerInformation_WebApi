namespace CustomerInformation_Web.Data
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
        public ErrorDescription error { get; set; }
    }

    public class ErrorDescription
    {
        public string message { get; set; }
        public string description { get; set; }
    }

}
