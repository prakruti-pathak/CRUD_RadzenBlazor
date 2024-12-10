using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUDRadzenBlazor.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
