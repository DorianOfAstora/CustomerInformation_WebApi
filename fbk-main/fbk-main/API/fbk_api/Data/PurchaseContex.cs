using Microsoft.EntityFrameworkCore;
using fbk_api.Models;

namespace fbk_api.Data
{
    public class PurchaseContex : DbContext{

        public PurchaseContex(DbContextOptions<PurchaseContex> options):base(options){

        }

        public DbSet<Purchase> Purchases {set; get;}
    }
}