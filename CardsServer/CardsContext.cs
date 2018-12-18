using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CardsServer
{
    public class CardsContext : DbContext
    {
        public CardsContext(DbContextOptions<CardsContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
