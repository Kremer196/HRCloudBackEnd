using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemShop.Models;

namespace MyItemShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BaseController<Cart, CartDTO>
    {


        public CartsController(UserContext context, IMapper mapper) : base(context, mapper)
        {

        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<IEnumerable<CartDTO>>> GetOne(int id)
        {
           

            var userCart = await (from item in _context.Cart
                           where item.ID == id
                           select item).ToListAsync();

            if (userCart == null)
            {
                return NotFound();
            }

            return Ok(userCart);
        }


        [HttpGet("{id}/{itemID}")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetOneItem(int id, int itemID)
        {
            var one = await dbSet.FindAsync(id, itemID);

            if (one == null)
            {
                return NotFound();
            }

            return Ok(one);
        }

        [HttpPut("{id}/{itemID}/plus")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> PutOnePlus(int id, int itemID, CartDTO model)
        {
            var one = await dbSet.FindAsync(id, itemID);

            if (one == null)
            {
                return NotFound();
            } else
            {
                one.Quantity = one.Quantity + 1;

                await _context.SaveChangesAsync();

                return NoContent();
            }

            
        }

        [HttpPut("{id}/{itemID}/minus")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> PutOneMinus(int id, int itemID, CartDTO model)
        {
            var one = await dbSet.FindAsync(id, itemID);

            if (one == null)
            {
                return NotFound();
            }
            else
            {
                one.Quantity = one.Quantity - 1;

                if(one.Quantity == 0)
                {
                   await DeleteOneItem(id, itemID);
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }


        }


        [HttpDelete("{id}/{itemID}")]
        public async Task<IActionResult> DeleteOneItem(int id, int itemID)
        {
            var model = await dbSet.FindAsync(id, itemID);
            if (model == null)
            {
                return NotFound();
            }

            dbSet.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
