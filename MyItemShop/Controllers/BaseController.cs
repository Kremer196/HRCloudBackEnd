using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, VEntity> : ControllerBase 
        where TEntity : Models.BaseClass
        where VEntity : Models.BaseDTO
    {
        protected readonly UserContext _context;
        protected DbSet<TEntity> dbSet { get; set; }


        public BaseController(UserContext context) 
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VEntity>>> GetAll()
        {
            var list = await dbSet.ToListAsync();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VEntity>>> GetOne(int id)
        {
            var one = await dbSet.FindAsync(id);

            if (one == null)
            {
                return NotFound();
            }

            return Ok(one);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOne(int id, VEntity model)
        {
            if(id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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


        [HttpPost]
        public async Task<ActionResult<VEntity>> PostOne(TEntity model) {
            dbSet.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOne", new { id = model.ID }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var model = await dbSet.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            dbSet.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ModelExists(int id)
        {
            
            return dbSet.Any(e => e.ID == id);
        }

    }
}
