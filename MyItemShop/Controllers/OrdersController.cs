using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemShop.Models;



namespace MyItemShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UserContext _context;

        public OrdersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            
            List<Order> orders =  await _context.Orders.ToListAsync();

            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            foreach(var order in orders)
            {
                orderDTOs.Add(new OrderDTO(order));
            }

            return orderDTOs;
        }

        // GET: api/Orders/5
        [HttpGet("{userID}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int userID)
        {
            var order = await _context.Orders.FindAsync(userID);
           

            if (order == null)
            {
                return NotFound();
            } else
            {
                OrderDTO orderDTO = new OrderDTO(order);
                return orderDTO;
            }

            
        }

        [HttpGet("{userID}/list")]
        public async Task<ActionResult<IEnumerable<OrderedItem>>> GetOrderItems(int userID)
        {
            var ordersReturn = (await _context.Orders.FindAsync(userID));
            var orders = _context.Orders.Include(o => o.OrderedItems).ToList();


            if (ordersReturn != null)
            {

                return ordersReturn.OrderedItems;
            }
            return NotFound();
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userID}")]
        public async Task<IActionResult> PutOrder(int userID,  OrderDTO order)
        {
           /* var oldOrder = (from d in _context.Orders
                            where d.UserID == userID
                            select d).Single();*/

            var oldOrder = await _context.Orders.FindAsync(userID);

            var orders = _context.Orders.Include(o => o.OrderedItems).ToList();

            if(oldOrder.OrderedItems == null)
            {
                oldOrder.OrderedItems = new List<OrderedItem>();
            }


           foreach(var o in order.OrderedItems)
            {
                oldOrder.OrderedItems.Add(o);
                _context.SaveChanges();
            }








            try
            {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(userID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDTO)
        {

        
            _context.Orders.Add(new Order(orderDTO));
             
            
           
            await _context.SaveChangesAsync();

            var oldOrder = (from d in _context.Orders
                            where d.UserID == orderDTO.UserID
                            select d).Single();


            return CreatedAtAction("GetOrder", new { id = orderDTO.UserID }, orderDTO);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteOrder(int userID)
        {
            
            var order = await _context.Orders.FindAsync(userID);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int userID)
        {
            return _context.Orders.Any(e => e.UserID == userID);
        }
    }
}
