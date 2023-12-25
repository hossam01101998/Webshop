using Webshop.Models;

namespace Webshop.Data
{
    public class Initializer
    {
        public static void DbSetInitializer(WebshopContext context)
        {
            if (!context.Product.Any())
            {
                context.AddRange(
                    new Product { Name = "Car Wax", Details = "Premium car wax for a shiny finish", Price = 14.99M },
                    new Product { Name = "Dashboard Cleaner", Details = "Cleans and protects your dashboard", Price = 9.99M },
                    new Product { Name = "Tire Shine Spray", Details = "Gives tires a glossy finish", Price = 12.99M },
                    new Product { Name = "Car Air Freshener", Details = "Long-lasting fresh scent for your car", Price = 7.99M },
                    new Product { Name = "Engine Oil - Synthetic Blend", Details = "High-performance synthetic blend oil", Price = 29.99M },
                    new Product { Name = "Car Battery Charger", Details = "Charges and maintains car batteries", Price = 49.99M },
                    new Product { Name = "Car Wash Kit", Details = "Complete kit for a thorough car wash", Price = 39.99M },
                    new Product { Name = "Windshield Wipers (Pair)", Details = "Durable wipers for clear visibility", Price = 15.99M },
                    new Product { Name = "OBD-II Scanner", Details = "Diagnostic tool for car troubleshooting", Price = 89.99M }
                );

                context.SaveChanges();
            }
        }
    }
}

