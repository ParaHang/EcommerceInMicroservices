﻿using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }


}
