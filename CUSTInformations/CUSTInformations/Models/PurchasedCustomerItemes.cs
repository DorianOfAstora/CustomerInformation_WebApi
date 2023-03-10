namespace CUSTInformations.Models
{
    public class PurchasedCustomerItemes
    {
        public string customerNumber { get; set; }
        public DateTime purchaseDate { get; set; }
        public List<string> purchasedItems = new List<string>();
    }
}
