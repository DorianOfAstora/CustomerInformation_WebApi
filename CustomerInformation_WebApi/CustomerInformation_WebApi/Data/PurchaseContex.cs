using Microsoft.EntityFrameworkCore;
using CustomerInformation_WebApi.Models;

namespace CustomerInformation_WebApi.Data
{
    public class PurchaseContex : DbContext{

        public PurchaseContex(DbContextOptions<PurchaseContex> options):base(options){

        }

        public DbSet<Purchase> Purchases {set; get;}
    }
}