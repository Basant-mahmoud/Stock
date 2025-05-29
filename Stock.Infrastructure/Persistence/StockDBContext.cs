using Stock.Stock.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Stock.Stock.Infrastructure.Persistence
{
    public class StockDBContext : IdentityDbContext<ApplicationUser>
    {
        public StockDBContext(DbContextOptions<StockDBContext> options):base(options) 
        { 

        }
        public DbSet<Item> Items { get; set; }


    }
}
