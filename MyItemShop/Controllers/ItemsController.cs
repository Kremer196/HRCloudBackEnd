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
    public class ItemsController : ControllerBase
    {
        private readonly UserContext _context;

        public ItemsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {

            List<Item> list =  await _context.Items.ToListAsync();

            List<ItemDTO> returnList = new List<ItemDTO>();

            foreach(var item in list)
            {
                returnList.Add(new ItemDTO(item.ItemID, item.ItemName, item.CategoryID, item.ItemPrice, item.ItemImageURL));
            }

            return returnList;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
           

            
            

            if (item == null)
            {
                return NotFound();
            } else
            {
                ItemDTO itemDTO = new ItemDTO(item.ItemID, item.ItemName, item.CategoryID,  item.ItemPrice, item.ItemImageURL);
                return itemDTO;
            }


           
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            if (id != itemDTO.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(itemDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        {
            _context.Items.Add(new Item(itemDTO));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = itemDTO.ItemID }, itemDTO);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
