using ShopifyChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopifyChallengeAPI.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        //Populates the db with data from this method when the application runs for the first time
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            var products = new List<Product>
            {
                new Product{ProductName = "Milk", ProductValue = 30},
                new Product{ProductName = "Sugar", ProductValue = 20}
            };

            var lineItems = new List<LineItem>
            {
                new LineItem{Product = products[0], Quantity = 3, LineItemValue = products[0].ProductValue * 3},
                new LineItem{Product = products[1], Quantity = 5, LineItemValue = products[1].ProductValue * 5}
            };

            var orders = new List<Order>
            {
                new Order{ LineItems = lineItems, OrderValue = lineItems[0].LineItemValue + lineItems[1].LineItemValue}
            };

            var shop = new Shop { Products = products, Orders = orders };

            context.Shops.Add(shop);
            context.SaveChanges();

        }


    }
}