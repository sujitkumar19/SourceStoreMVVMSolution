namespace SportsStoreDomainLibrary2.DataContexts.SportsStoreMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SportsStoreDomainLibrary2.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsStoreDomainLibrary2.Concrete.SportsStoreDBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\SportsStoreMigrations";
        }

        protected override void Seed(SportsStoreDomainLibrary2.Concrete.SportsStoreDBcontext context)
        {
            context.Products.AddOrUpdate(p => p.ProductName,
                   new Product { ProductName = "Kayak", Description = "A boat for one person", price = 275.00m, category = "Watersports" },
                   new Product { ProductName = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", price = 29.95m, category = "Chess" },
                   new Product { ProductName = "Lifejacket", Description = "Protective and fashionable", price = 48.95m, category = "Watersports" },
                   new Product { ProductName = "Soccer ball", Description = "FIFA-approved size and weight", price = 19.50m, category = "Soccer" },
                   new Product { ProductName = "Spalding Ball", Description = "NBA official Basketball", price = 160.00m, category = "Basketball" },
                   new Product { ProductName = "Corner flags", Description = "Give your playing field that professional touch", price = 34.95m, category = "Soccer" },
                   new Product { ProductName = "Stadium", Description = "Flat-packed 35,000-seat stadium", price = 79500.00m, category = "Soccer" },
                   new Product { ProductName = "Thinking cap", Description = "Improve your brain efficiency by 75%", price = 16.00m, category = "Chess" },
                   new Product { ProductName = "Ring Net", Description = "NBA size ring nets", price = 60.00m, category = "Basketball" },
                   new Product { ProductName = "Human Chess", Description = "A fun game for the whole family", price = 75.00m, category = "Chess" },
                   new Product { ProductName = "Bling-bling King", Description = "Gold-plated, diamond-studded King", price = 1200.00m, category = "Chess" },
                   new Product { ProductName = "Dark Night", Description = "Titanium-plated Knight", price = 800.00m, category = "Chess" },
                   new Product { ProductName = "Shoe", Description = "Studded shoes", price = 950.00m, category = "Soccer" },
                   new Product { ProductName = "Basketball Boards", Description = "Full size NBA size Boards", price = 2160.00m, category = "Basketball" },
                   new Product { ProductName = "Jersey", Description = "Air Jersey", price = 1200.00m, category = "Soccer" },
                   new Product { ProductName = "Scooter", Description = "A water bike for one or two people", price = 4275.00m, category = "Watersports" },
                   new Product { ProductName = "Fox 40 whistle", Description = "NBA Referres Whistel", price = 160.00m, category = "Basketball" },
                   new Product { ProductName = "Surfboard", Description = "Surfboard for surfing on water", price = 495.00m, category = "Watersports" });
            #region Default
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            // 
            #endregion
        }
    }
}
