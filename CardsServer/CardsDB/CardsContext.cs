using CardsServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsServer.CardsDB
{
    public class CardsContext : DbContext
    {
        public CardsContext(DbContextOptions<CardsContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
