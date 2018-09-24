using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopifyChallengeAPI.Models
{
    //Contains all the class that represent the enities
    
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Order> Orders { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductValue { get; set; }
        
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
       // public int LineItemId { get; set; } //foreign key for Line Item
        public virtual List<LineItem> LineItems { get; set; } 
        public double OrderValue { get; set; }
    }

    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int ProductId { get; set; } //foreign key for Product
        public virtual Product Product { get; set; }//foreign key for Product
        public int Quantity { get; set; }
        public double LineItemValue { get; set; }
    }

   
}