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

                var reviews = new List<Review>
                {
                    new Review { appliesTo = items.SingleOrDefault(i => i.name.Equals("Veggie Burger")), review = "The veggie burger was great! Perfectly done, would recommend even to non-vegetarians.",
                                 reviewValue = 10, submitter = "Jane", repliedTo = true, reviewDate = new DateTime(2015, 11, 20), reply = "Good to hear you liked it!"},
                    new Review { appliesTo = items.SingleOrDefault(i => i.name.Equals("Fresh Garden Salad")), review = "Wife made me eat this, why would you even offer rabbit food at a burger shop?!",
                                 reviewValue = 1, reviewDate = new DateTime(2015, 11, 20), repliedTo = true, submitter = "John", 
                                 reply = "Hi John, we are very sorry to hear that you did not like our salad." + 
                                 "We offer salads because some customers prefer to eat a salad while the rest of their family eats burgers - and we try to cater for everybody."},
                    new Review { appliesTo = items.SingleOrDefault(i => i.name.Equals("Family Feast")), review = "The entire family loved it! We'll definitely be back!", reviewValue = 10,
                                 reviewDate = new DateTime(2015, 11, 21), submitter = "James", repliedTo = true, reply = "That's great to hear, James! You are welcome back anytime!"},
                    new Review { appliesTo = items.SingleOrDefault(i => i.name.Equals("8 BBQ Ribs")), review = "the ribs were just meh ive had better from other shops", reviewValue = 4,
                                 reviewDate = new DateTime(2015, 11, 22), submitter = "Jim", repliedTo = false}
                };
                reviews.ForEach(r => context.Reviews.AddOrUpdate(p => p.submitter, r));
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
        public System.Data.Entity.DbSet<NandosoAPI.Models.Review> Reviews { get; set; }
    }
}
