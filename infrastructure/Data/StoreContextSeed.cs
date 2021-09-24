using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
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

            } catch(Exception err) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(err.Message);

            }

        }
    }
}