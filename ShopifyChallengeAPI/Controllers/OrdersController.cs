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

    /// <summary>
    /// Class ordersController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private DatabaseContext db = new DatabaseContext();
        /// <summary>
        /// The helper
        /// </summary>
        HelperClass helper = new HelperClass();

        // GET: api/Products
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;Order&gt;.</returns>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return db.Orders.ToList();
        }

        // GET: api/Products/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //Product product = db.Products.Find(id);
            Order order = db.Orders.FirstOrDefault(x => x.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // GET: api/Products/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="order">The order.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            Order savedOrder = helper.UpdateOrder(id, order);
            if (savedOrder == null)
            {
                return NotFound();
            }
            return Ok(savedOrder);

        }

        // GET: api/Products
        /// <summary>
        /// Posts the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            helper.SaveOrder(order);
            return Ok();
        }

        // GET: api/Orders
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid product id");
            Order order = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            if (order == null)
                return NotFound();
            db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }




    }
}
