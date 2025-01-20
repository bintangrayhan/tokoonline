
using TokoOnline.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace TokoOnline.Controllers
{
    public class TokoOnlineController : ControllerBase
    {
        private static List<Order> orders = new List<Order>
        {
            new Order {Id = 1, Customer_name = "jamal", order_date = 12, Shipping_address = "antapani", Status = "dikemas", Total_price = 10000},
             new Order {Id = 2, Customer_name = "udin", order_date = 12, Shipping_address = "antapani", Status = "dikemas", Total_price = 10000},
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = orders.Find(m => m.Id == id);
            if (order == null) return NotFound();
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            order.Id = orders.Count + 1;
            orders.Add(order);
            return CreatedAtAction(nameof(GetById), new { Id = order.Id }, order);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order updadateOrder)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = orders.Find(m => m.Id == id);
            if (order == null) return NotFound();

            order.Customer_name = updadateOrder.Customer_name;
            order.Shipping_address = updadateOrder.Shipping_address;
            order.Total_price = updadateOrder.Total_price;
            order.order_date = updadateOrder.order_date;
            order.Status = updadateOrder.Status;


            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = orders.Find(m => m.Id == id);
            if (order == null) return NotFound();

            orders.Remove(order);
            return NoContent();
        }

    }
}
