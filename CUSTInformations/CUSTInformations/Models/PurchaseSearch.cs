namespace CUSTInformations.Models
{
    public class PurchaseSearch
    {
    }
    public class GeneralPurchaseSearch
    {
        public string? customerNumber { get; set; }
        public string? item { get; set; }
    }
    public class PurchasePerMonthSearch
    {
        public string? customerNumber { get; set; }
        public string? item { get; set; }
        public DateTime? datePurchase { get; set; }
    }
}
