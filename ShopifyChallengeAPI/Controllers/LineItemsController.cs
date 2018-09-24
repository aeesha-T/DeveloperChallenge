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
    [RoutePrefix("api/lineitems")]
    public class LineItemsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        HelperClass helper = new HelperClass();

        // GET: api/LineItems
        [HttpGet]
        public IEnumerable<LineItem> Get()
        {
            return db.LineItems.ToList();
        }

        // GET: api/LineItems/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //Product product = db.Products.Find(id);
            LineItem lineitem = db.LineItems.FirstOrDefault(x => x.LineItemId == id);
            if (lineitem == null)
            {
                return NotFound();
            }
            return Ok(lineitem);
        }

        // PUT: api/LineItem/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]LineItem lineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            LineItem lineItemUpdated = helper.UpdateLineItem(id, lineItem);
            if (lineItemUpdated == null)
            {
                return NotFound();
            }
            return Ok(lineItemUpdated);

        }

        // GET: api/LineItems
        [HttpPost]
        public IHttpActionResult Post([FromBody]LineItem lineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            if (db.Products.FirstOrDefault(x => x.ProductId == lineItem.ProductId) == null)
            {
                return BadRequest("This product Id does not exist");
            }
            var result = helper.SaveLineItem(lineItem);
                return Ok(result);
            
        }

        // GET: api/LineItems
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid line item Id");
            LineItem lineItem = db.LineItems.Where(x => x.LineItemId == id).FirstOrDefault();
            if (lineItem == null)
                return NotFound();
            db.Entry(lineItem).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }




    }
}
