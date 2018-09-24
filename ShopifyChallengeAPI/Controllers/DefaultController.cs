using ShopifyChallengeAPI.Context;
using ShopifyChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopifyChallengeAPI.Controllers
{
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Default/Products
        [HttpGet]
        [Route("products")]
        public IQueryable<Product> Products()
        {
            return db.Products;
        }

        // GET: api/Default/shops
        [HttpGet]
        [Route("shops")]
        public IEnumerable<Shop> Shops()
        {
            return db.Shops.ToList();
        }

        // GET: api/Default/LineItems
        [HttpGet]
        [Route("LineItems")]
        public IEnumerable<LineItem> LineItems()
        {
            return db.LineItems.ToList();
        }

        // GET: api/Default/orders
        [HttpGet]
        [Route("Orders")]
        public IEnumerable<Order> Orders()
        {
            return db.Orders.ToList();
        }

        // GET: api/Default/Product/5
        [HttpGet]
        [Route("product/{id}")]
        public Product GetProduct(int id)
        {
            //Product product = db.Products.Find(id);
            Product product = db.Products.FirstOrDefault(x=>x.ProductId == id);
            return product;
        }

        // GET: api/Default/Shop/5
        [HttpGet]
        [Route("shop/{id}")]
        public Shop GetShop(int id)
        {
            //Product product = db.Products.Find(id);
            Shop shop = db.Shops.FirstOrDefault(x => x.ShopId == id);
            return shop;
        }


        // GET: api/Default/Order/5
        [HttpGet]
        [Route("order/{id}")]
        public Order GetOrder(int id)
        {
            //Product product = db.Products.Find(id);
            Order order = db.Orders.FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        // GET: api/Default/lineItem/5
        [HttpGet]
        [Route("lineItem/{id}")]
        public LineItem GetLineItem(int id)
        {
            //Product product = db.Products.Find(id);
            LineItem lineItem = db.LineItems.FirstOrDefault(x => x.LineItemId == id);
            return lineItem;
        }


    }
}
