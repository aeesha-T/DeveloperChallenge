using ShopifyChallengeAPI.Context;
using ShopifyChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopifyChallengeAPI.Helper
{
    public class HelperClass
    {
        private DatabaseContext db = new DatabaseContext();

        public Product UpdateProduct(long id, Product product)
        {
            //Retrieve the product using the ID
            var retrievedProduct = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (retrievedProduct != null)
            {
                long saveProductId = 0;
                if (product != null)
                {
                    retrievedProduct.ProductName = product.ProductName == null ? retrievedProduct.ProductName : product.ProductName;
                    retrievedProduct.ProductValue = product.ProductValue == 0 ? retrievedProduct.ProductValue : product.ProductValue;

                    saveProductId = db.SaveChanges();
                }
            }
            return retrievedProduct;
        }

        public long SaveProduct(Product product)
        {
            long saveProductId = 0;

            if (product != null)
            {
                db.Products.Add(product);

                saveProductId = db.SaveChanges();
            }
            return saveProductId;
        }

        public LineItem SaveLineItem(LineItem lineItem)
        {
            var lineItemEntity = new LineItem();
            try
            {
                if (lineItem != null)
                {
                    lineItemEntity.ProductId = lineItem.ProductId;
                    var product = db.Products.Where(x => x.ProductId == lineItem.ProductId).FirstOrDefault();
                    lineItemEntity.Product = product;
                    lineItemEntity.Quantity = lineItem.Quantity;
                    lineItemEntity.LineItemValue = lineItem.Quantity * product.ProductValue;
                    db.LineItems.Add(lineItemEntity);
                    db.SaveChanges();
                }
                return lineItemEntity;
            }
            catch
            {
                return null;
            }
        }

        public LineItem UpdateLineItem(long id, LineItem lineItem)
        {
            //Retrieve the product using the ID
            var retrievedLineItem = db.LineItems.FirstOrDefault(x => x.LineItemId == id);
            if (retrievedLineItem != null)
            {
                //long saveProductId = 0;
                if (lineItem != null)
                {

                    if (lineItem.ProductId != 0)
                    {
                        var product = db.Products.Where(x => x.ProductId == lineItem.ProductId).FirstOrDefault();
                        retrievedLineItem.ProductId = lineItem.ProductId;
                        retrievedLineItem.Product = product;
                    }
                    retrievedLineItem.Quantity = lineItem.Quantity == 0 ? retrievedLineItem.Quantity : lineItem.Quantity;
                    retrievedLineItem.LineItemValue = retrievedLineItem.Product.ProductValue * retrievedLineItem.Quantity;

                    db.SaveChanges();
                }
            }
            return retrievedLineItem;
        }

        public Order SaveOrder(Order order)
        {
            var orderEntity = new Order();
            try
            {
                if (order != null)
                {
                    orderEntity.LineItems = order.LineItems;
                    double totalOrderValue = 0;
                    for (int x = 0; x < order.LineItems.Count; x++)
                    {
                        totalOrderValue += order.LineItems[x].LineItemValue;
                    }
                    orderEntity.OrderValue = totalOrderValue;
                    db.Orders.Add(orderEntity);
                    db.SaveChanges();
                }
                return orderEntity;
            }
            catch
            {
                return null;
            }
        }

        public Order UpdateOrder(long id, Order order)
        {
            //Retrieve the product using the ID
            var retrievedOrder = db.Orders.FirstOrDefault(x => x.OrderId == id);
            if (retrievedOrder != null)
            {
                //long saveProductId = 0;
                if (order != null)
                {

                    if (order.LineItems.Count > 0)
                    {
                        for (int i = 0; i < order.LineItems.Count; i++)
                        {
                            var lineItem = db.LineItems.Where(x => x.Product.ProductName == order.LineItems[i].Product.ProductName).FirstOrDefault();
                            //review
                            retrievedOrder.OrderValue += lineItem.LineItemValue;

                        }
                    }
                    db.SaveChanges();
                }
            }
            return retrievedOrder;
        }


    }
}