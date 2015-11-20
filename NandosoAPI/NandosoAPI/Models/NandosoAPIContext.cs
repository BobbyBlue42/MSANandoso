using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NandosoAPI.Models
{
    public class NandosoAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<NandosoAPIContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(NandosoAPIContext context)
            {
                var items = new List<Item>
                {
                    new Item{ name = "Veggie Paella", vegetarian = true, glutenFree = true, price = 13.9, discount = 15},
                    new Item{ name = "Veggie Wrap", vegetarian = true, glutenFree = false, price = 9.9, discount = 20},
                    new Item{ name = "Veggie Burger", vegetarian = true, glutenFree = false, price = 9.9, discount = 15},
                    new Item{ name = "Quarter Chicken", vegetarian = false, glutenFree = true, price = 8.9, discount = 12.5},
                    new Item{ name = "Half Chicken", vegetarian = false, glutenFree = true, price = 12.9, discount = 10},
                    new Item{ name = "8 BBQ Ribs", vegetarian = false, glutenFree = true, price = 11.9, discount = 0},
                    new Item{ name = "Mixed Platter", vegetarian = false, glutenFree = true, price = 33.9, discount = 5},
                    new Item{ name = "Family Feast", vegetarian = false, glutenFree = true, price = 44.9, discount = 5},
                    new Item{ name = "Chicken Breast Pita", vegetarian = false, glutenFree = false, price = 9.9, discount = 0},
                    new Item{ name = "Fresh Garden Salad", vegetarian = true, glutenFree = true, price = 8.9, discount = 0}
                };
                items.ForEach(s => context.Items.AddOrUpdate(p => p.name, s));
                context.SaveChanges();
                Admin admin = new Admin("admin", "admin");
                context.Admins.AddOrUpdate(admin);
                context.SaveChanges();
            }
        }


        public NandosoAPIContext()
            : base("name=NandosoAPIContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoAPIContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<NandosoAPI.Models.Item> Items { get; set; }
        public System.Data.Entity.DbSet<NandosoAPI.Models.Admin> Admins { get; set; }
    }
}
