using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Entities;
using Core.Entities.hr;
using Core.Entities.identity;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data {
        public class StoreContext : DbContext {
         
        public StoreContext (DbContextOptions<StoreContext>  options) : base (options) { }
          public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
       
               public DbSet<Order> Orders { get; set; }
               public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<DelivaryMethod> DelivaryMethods { get; set; }

     
       public DbSet<ProductWebSite> ProductsWebSite { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Employeeleaves> Employeeleaves { get; set; }
           public DbSet<Employees> Employees { get; set; }
                 public DbSet<Departments> Departments { get; set; }
                                  public DbSet<Holidays> Holidays { get; set; }
     public DbSet<Designation> Designation { get; set; }
     
 
       
        protected override void OnModelCreating(ModelBuilder modelBuilder) {




            base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite") {
                foreach(var entityType in modelBuilder.Model.GetEntityTypes()){
                 var properties= entityType.ClrType.GetProperties().Where(p=>p.PropertyType==typeof(decimal));
var dataTimeProperty = entityType.ClrType.GetProperties().Where(p=>p.PropertyType == typeof(DateTimeOffset));


              foreach(var property in properties){
                  modelBuilder.Entity(entityType.Name).Property(property.
                  Name).HasConversion<double>();
                  
              }
              foreach(var property in dataTimeProperty) {
                modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
              }
                }

          
           }
                 modelBuilder.Entity<ProductWebSite>()
            .Property(e => e.tags)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
  modelBuilder.Entity<ProductWebSite>()
          .HasMany(i=>i.images).WithOne(p=>p.ProductWebSite).HasForeignKey(
            e=>e.ProductWebSiteId
          );
        }

    }
}                                                                                                                                                                         