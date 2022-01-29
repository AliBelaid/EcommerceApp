using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.hr;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data {
    public class StoreContextSeed {
        public static async Task SeedAsync (StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if (!context.ProductBrand.Any ()) {
                    var brander = File.ReadAllText ("../Infrastructure/Data/SeedData/brands.json");
                    var items = JsonSerializer.Deserialize<List<ProductBrand>> (brander);
                    foreach (var item in items) {

                        context.ProductBrand.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }
                if (!context.ProductType.Any ()) {
                    var brander = File.ReadAllText ("../Infrastructure/Data/SeedData/types.json");
                    var items = JsonSerializer.Deserialize<List<ProductType>> (brander);
                    foreach (var item in items) {

                        context.ProductType.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }

                if (!context.Products.Any ()) {
                    var brander = File.ReadAllText ("../Infrastructure/Data/SeedData/products.json");
                    var items = JsonSerializer.Deserialize<List<Product>> (brander);
                    foreach (var item in items) {

                        context.Products.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }

                  if (!context.DelivaryMethods.Any ()) {
                    var Delivary = File.ReadAllText ("../Infrastructure/Data/SeedData/delivery.json");
                    var items = JsonSerializer.Deserialize<List<DelivaryMethod>> (Delivary);
                    foreach (var item in items) {

                        context.DelivaryMethods.Add(item);

                    }
                    await context.SaveChangesAsync ();
                }

                    if (!context.ProductsWebSite.Any()) {
                    var prodWeb = File.ReadAllText ("../Infrastructure/Data/SeedData/webdata/products.json");
                    var items = JsonSerializer.Deserialize<List<ProductWebSite>> (prodWeb);
                    foreach (var item in items) {
                         
                        context.ProductsWebSite.Add(item);

                    }
                    await context.SaveChangesAsync ();
                }

        if (!context.Departments.Any ()) {
                    var Departments = File.ReadAllText ("../Infrastructure/Data/SeedData/hrJson/departments.json");
                    var items = JsonSerializer.Deserialize<List<Departments>> (Departments);
                    foreach (var item in items) {

                        context.Departments.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }

      if (!context.Designation.Any ()) {
                    var designation = File.ReadAllText ("../Infrastructure/Data/SeedData/hrJson/designation.json");
                    var items = JsonSerializer.Deserialize<List<Designation>> (designation);
                    foreach (var item in items) {

                        context.Designation.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }
    if (!context.Holidays.Any ()) {
                    var holidays = File.ReadAllText ("../Infrastructure/Data/SeedData/hrJson/holidays.json");
                    var items = JsonSerializer.Deserialize<List<Holidays>> (holidays);
                    foreach (var item in items) {

                        context.Holidays.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }

    if (!context.Employees.Any ()) {
                    var employees = File.ReadAllText ("../Infrastructure/Data/SeedData/hrJson/employeelist.json");
                    var items = JsonSerializer.Deserialize<List<Employees>> (employees);
                    foreach (var item in items) {

                        context.Employees.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }
    if (!context.Employeeleaves.Any ()) {
                    var Employeeleaves = File.ReadAllText ("../Infrastructure/Data/SeedData/hrJson/employeeleaves.json");
                    var items = JsonSerializer.Deserialize<List<Employeeleaves>> (Employeeleaves);
                    foreach (var item in items) {

                        context.Employeeleaves.Add (item);

                    }
                    await context.SaveChangesAsync ();
                }
            } catch(Exception err) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(err.Message);

            }

        }
    }
}