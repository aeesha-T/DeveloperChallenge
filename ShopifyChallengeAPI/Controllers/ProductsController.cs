using ShopifyChallengeAPI.Context;
using ShopifyChallengeAPI.Helper;
using ShopifyChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopifyChallengeAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        HelperClass helper = new HelperClass();

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //Product product = db.Products.Find(id);
            Product product = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET: api/Products/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            Product savedProduct = helper.UpdateProduct(id, product);
            if (savedProduct == null)
            {
                return NotFound();
            }
            return Ok(savedProduct);

        }

        // GET: api/Products
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            helper.SaveProduct(product);
            return Ok();


        }

        // GET: api/Products
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid product id");
            Product product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
                return NotFound();
            db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();


            return Ok();
        }




    }
}
