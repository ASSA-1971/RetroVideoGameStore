using Microsoft.AspNetCore.Identity;
using RetroVideoGameStore.Models;

namespace RetroVideoGameStore.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they don't exist
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            // Seed admin user
            if (await userManager.FindByEmailAsync("admin@retrogames.com") == null)
            {
                var admin = new IdentityUser
                {
                    UserName = "admin@retrogames.com",
                    Email = "admin@retrogames.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, "Admin1234!");
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

            // Seed customer 1
            if (await userManager.FindByEmailAsync("alex@email.com") == null)
            {
                var customer1 = new IdentityUser
                {
                    UserName = "alex@email.com",
                    Email = "alex@email.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(customer1, "Customer1234!");
                await userManager.AddToRoleAsync(customer1, "Customer");
            }

            // Seed customer 2
            if (await userManager.FindByEmailAsync("sarah@email.com") == null)
            {
                var customer2 = new IdentityUser
                {
                    UserName = "sarah@email.com",
                    Email = "sarah@email.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(customer2, "Customer1234!");
                await userManager.AddToRoleAsync(customer2, "Customer");
            }

            // Seed categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "NES" },
                    new Category { Name = "SNES" },
                    new Category { Name = "Sega Genesis" },
                    new Category { Name = "Nintendo 64" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            // Seed products
            if (!context.Products.Any())
            {
                var nes = context.Categories.Single(c => c.Name == "NES").Id;
                var snes = context.Categories.Single(c => c.Name == "SNES").Id;
                var genesis = context.Categories.Single(c => c.Name == "Sega Genesis").Id;
                var n64 = context.Categories.Single(c => c.Name == "Nintendo 64").Id;

                var products = new List<Product>
                {
                    new Product { Name = "Super Mario Bros", Price = 29.99, CategoryId = nes, Description = "The classic platformer that started it all." },
                    new Product { Name = "The Legend of Zelda", Price = 34.99, CategoryId = nes, Description = "Go on an epic quest to save Princess Zelda." },
                    new Product { Name = "Mega Man 2", Price = 24.99, CategoryId = nes, Description = "One of the best action platformers ever made." },
                    new Product { Name = "Super Mario World", Price = 39.99, CategoryId = snes, Description = "Mario's first outing on the Super Nintendo." },
                    new Product { Name = "Street Fighter II", Price = 29.99, CategoryId = snes, Description = "The definitive fighting game of a generation." },
                    new Product { Name = "Donkey Kong Country", Price = 34.99, CategoryId = snes, Description = "Stunning visuals and tight platforming gameplay." },
                    new Product { Name = "Sonic the Hedgehog", Price = 24.99, CategoryId = genesis, Description = "Sega's answer to Mario — speed is the name of the game." },
                    new Product { Name = "Mortal Kombat", Price = 29.99, CategoryId = genesis, Description = "Finish him! The brutal arcade fighter comes home." },
                    new Product { Name = "Super Mario 64", Price = 49.99, CategoryId = n64, Description = "The game that defined 3D platforming forever." },
                    new Product { Name = "GoldenEye 007", Price = 44.99, CategoryId = n64, Description = "Still one of the greatest multiplayer games ever made." },
                    new Product { Name = "The Legend of Zelda: Ocarina of Time", Price = 54.99, CategoryId = n64, Description = "Widely considered one of the greatest games of all time." }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Seed orders
            if (!context.Orders.Any())
            {
                var marioId = context.Products.Single(p => p.Name == "Super Mario Bros").Id;
                var zeldaN64Id = context.Products.Single(p => p.Name == "The Legend of Zelda: Ocarina of Time").Id;
                var sonicId = context.Products.Single(p => p.Name == "Sonic the Hedgehog").Id;
                var mario64Id = context.Products.Single(p => p.Name == "Super Mario 64").Id;
                var sfighterId = context.Products.Single(p => p.Name == "Street Fighter II").Id;
                var goldeneyeId = context.Products.Single(p => p.Name == "GoldenEye 007").Id;
                var megamanId = context.Products.Single(p => p.Name == "Mega Man 2").Id;

                var orders = new List<Order>
                {
                    new Order
                    {
                        CustomerId = "alex@email.com",
                        FirstName = "Alex",
                        LastName = "Johnson",
                        Address = "123 Main St",
                        City = "Toronto",
                        Province = "ON",
                        PostalCode = "M5V 1A1",
                        Phone = "416-555-0101",
                        OrderDate = DateTime.Now.AddDays(-20),
                        OrderTotal = 84.98,
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId = marioId, Quantity = 1, Price = 29.99 },
                            new OrderDetail { ProductId = zeldaN64Id, Quantity = 1, Price = 54.99 }
                        }
                    },
                    new Order
                    {
                        CustomerId = "alex@email.com",
                        FirstName = "Alex",
                        LastName = "Johnson",
                        Address = "123 Main St",
                        City = "Toronto",
                        Province = "ON",
                        PostalCode = "M5V 1A1",
                        Phone = "416-555-0101",
                        OrderDate = DateTime.Now.AddDays(-10),
                        OrderTotal = 74.98,
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId = mario64Id, Quantity = 1, Price = 49.99 },
                            new OrderDetail { ProductId = sonicId, Quantity = 1, Price = 24.99 }
                        }
                    },
                    new Order
                    {
                        CustomerId = "sarah@email.com",
                        FirstName = "Sarah",
                        LastName = "Mitchell",
                        Address = "456 Queen St W",
                        City = "Toronto",
                        Province = "ON",
                        PostalCode = "M6J 1E3",
                        Phone = "647-555-0202",
                        OrderDate = DateTime.Now.AddDays(-15),
                        OrderTotal = 59.98,
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId = sfighterId, Quantity = 1, Price = 29.99 },
                            new OrderDetail { ProductId = megamanId, Quantity = 1, Price = 24.99 }
                        }
                    },
                    new Order
                    {
                        CustomerId = "sarah@email.com",
                        FirstName = "Sarah",
                        LastName = "Mitchell",
                        Address = "456 Queen St W",
                        City = "Toronto",
                        Province = "ON",
                        PostalCode = "M6J 1E3",
                        Phone = "647-555-0202",
                        OrderDate = DateTime.Now.AddDays(-5),
                        OrderTotal = 44.99,
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId = goldeneyeId, Quantity = 1, Price = 44.99 }
                        }
                    },
                    new Order
                    {
                        CustomerId = "alex@email.com",
                        FirstName = "Alex",
                        LastName = "Johnson",
                        Address = "123 Main St",
                        City = "Toronto",
                        Province = "ON",
                        PostalCode = "M5V 1A1",
                        Phone = "416-555-0101",
                        OrderDate = DateTime.Now.AddDays(-3),
                        OrderTotal = 34.99,
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId = zeldaN64Id, Quantity = 1, Price = 34.99 }
                        }
                    }
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}
