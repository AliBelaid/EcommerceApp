using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Core.Entities;
namespace infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
    }
}