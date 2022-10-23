using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIpub.Data;
using WebAPIpub.Models;

namespace WebAPIpub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyschedsController : ControllerBase
    {
        private readonly pubsContext _context;

        public RoyschedsController(pubsContext context)
        {
            _context = context;
        }

        // GET: api/Royscheds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roysched>>> GetRoyscheds()
        {
            return await _context.Royscheds.ToListAsync();
        }

        // GET: api/Royscheds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roysched>> GetRoysched(string id)
        {
            var roysched = await _context.Royscheds.FindAsync(id);

            if (roysched == null)
            {
                return NotFound();
            }

            return roysched;
        }

        // PUT: api/Royscheds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoysched(string id, Roysched roysched)
        {
            if (id != roysched.TitleId)
            {
                return BadRequest();
            }

            _context.Entry(roysched).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoyschedExists(id))
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

        // POST: api/Royscheds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roysched>> PostRoysched(Roysched roysched)
        {
            _context.Royscheds.Add(roysched);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoyschedExists(roysched.TitleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoysched", new { id = roysched.TitleId }, roysched);
        }

        // DELETE: api/Royscheds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoysched(string id)
        {
            var roysched = await _context.Royscheds.FindAsync(id);
            if (roysched == null)
            {
                return NotFound();
            }

            _context.Royscheds.Remove(roysched);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoyschedExists(string id)
        {
            return _context.Royscheds.Any(e => e.TitleId == id);
        }
    }
}
