using CUSTInformations.Models;
using Microsoft.OpenApi.Services;
using System.Globalization;

namespace CUSTInformations.CustomerFileUnpackager
{
    public class CustUnpackagerUtility
    {
        public List<PurchasedCustomerItemes> ReadPurchases()
        {
            var purchases = new List<PurchasedCustomerItemes>();
            var currentPurchase = new PurchasedCustomerItemes();

            foreach (var line in File.ReadLines("Purchases.dat"))
            {
                if (line.StartsWith("CUST"))
                {
                    currentPurchase = new PurchasedCustomerItemes();
                    currentPurchase.customerNumber = line.Substring(4);
                }
                else if (line.StartsWith("DATE"))
                {
                    var dateString = line.Substring(4);
                    currentPurchase.purchaseDate = DateTime.ParseExact(dateString, "ddMMyyyyHHmm", CultureInfo.InvariantCulture);
                }
                else if (line.StartsWith("ITEM"))
                {
                    var itemNumber = line.Substring(4);
                    currentPurchase.purchasedItems.Add(itemNumber);
                }
                purchases.Add(currentPurchase);
            }

            return purchases;
        }

        public PurchasesPerMonths ReadPurchasesPerMonths()
        {
            var customersByMonth = new PurchasesPerMonths();
            using (var reader = new StreamReader("purchases.dat"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("CUST"))
                    {
                        // Extract the purchase date from the previous DATE record
                        var previousLine = reader.ReadLine();

                        var parts = previousLine.Split("DATE");
                        var purchaseDate = DateTime.ParseExact(parts[1], "ddMMyyyyHHmm", CultureInfo.InvariantCulture);

                        // Increment the customer count for the month of the purchase date
                        var monthKey = purchaseDate.ToString("yyyy-MM");
                        if (!customersByMonth.distinctCustomers.ContainsKey(monthKey))
                        {
                            customersByMonth.distinctCustomers[monthKey] = 0;
                        }

                        customersByMonth.distinctCustomers[monthKey]++;
                    }
                }
            }
            return customersByMonth;
        }

    }
}
