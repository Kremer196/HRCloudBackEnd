using System;
using System.Collections.Generic;
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
    public class CartsController : ControllerBase
    {
        private readonly UserContext _context;

        public CartsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetCart()
        {
            List<Cart> cart = await _context.Cart.ToListAsync();

            List<CartDTO> cartItems = new List<CartDTO>();

            foreach (var cartItem in cart)
            {
                cartItems.Add(new CartDTO(cartItem));
            }

            return cartItems;
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDTO>> GetCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            CartDTO cartDTO = new CartDTO(cart);

            return cartDTO;
        }

        [HttpGet("{id}/list")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(int id)
        {
            var cartItems = await _context.Cart.FindAsync(id);
            var carts = _context.Cart.Include(o => o.CartItems).ToList();

            if (cartItems != null)
            {
                return cartItems.CartItems;
            }
            return NotFound();
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, CartDTO cartDTO)
        {

           


            var oldCart = await _context.Cart.FindAsync(id);

            var orders = _context.Cart.Include(o => o.CartItems).ToList();


            if (oldCart.CartItems == null)
            {
                oldCart.CartItems = new List<CartItem>();
            }


            foreach (var o in cartDTO.CartItems)
            {
                oldCart.CartItems.Add(o);

            }

         



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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


        //PUT: api/Carts/userID/itemID/plus
        [HttpPut("{userID}/{itemID}/plus")] 
        public async Task<IActionResult> PlusCart(int userID, int itemID, CartDTO cartDTO)
        {
            var oldCart = await _context.Cart.FindAsync(userID);

            var carts = _context.Cart.Include(o => o.CartItems).ToList();

            CartItem updateItem = null;

            foreach(var cartItem in oldCart.CartItems)
            {
                if(cartItem.ItemID == itemID)
                {
                    updateItem = cartItem;
                }
            }

            if(updateItem != null)
            {
                int currentQuantity = updateItem.Quantity;

                updateItem.Quantity = currentQuantity + 1;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(userID))
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


        //PUT: api/Carts/userID/itemID/minus
        [HttpPut("{userID}/{itemID}/minus")]
        public async Task<IActionResult> MinusCart(int userID, int itemID, CartDTO cartDTO)
        {
            var oldCart = await _context.Cart.FindAsync(userID);

            var carts = _context.Cart.Include(o => o.CartItems).ToList();

            CartItem updateItem = null;

            foreach (var cartItem in oldCart.CartItems)
            {
                if (cartItem.ItemID == itemID)
                {
                    updateItem = cartItem;
                }
            }

            if (updateItem != null)
            {
                int currentQuantity = updateItem.Quantity;

                updateItem.Quantity = currentQuantity - 1;
                
                if(updateItem.Quantity == 0)
                {
                    oldCart.CartItems.Remove(updateItem);
                  
                }
            }



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(userID))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartDTO>> PostCart(CartDTO cartDTO)
        {
            _context.Cart.Add(new Cart(cartDTO));

           

         //   _context.Entry(cartDTO).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();
           
          

            return CreatedAtAction("GetCart", new { id = cartDTO.UserID }, cartDTO);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.UserID == id);
        }
    }
}
