using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using System.Collections.Generic;

namespace OrderApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
