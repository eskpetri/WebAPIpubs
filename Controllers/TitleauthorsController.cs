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
    public class TitleauthorsController : ControllerBase
    {
        private readonly pubsContext _context;

        public TitleauthorsController(pubsContext context)
        {
            _context = context;
        }

        // GET: api/Titleauthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titleauthor>>> GetTitleauthors()
        {
            return await _context.Titleauthors.ToListAsync();
        }

        // GET: api/Titleauthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titleauthor>> GetTitleauthor(string id)
        {
            var titleauthor = await _context.Titleauthors.FindAsync(id);

            if (titleauthor == null)
            {
                return NotFound();
            }

            return titleauthor;
        }

        // PUT: api/Titleauthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleauthor(string id, Titleauthor titleauthor)
        {
            if (id != titleauthor.AuId)
            {
                return BadRequest();
            }

            _context.Entry(titleauthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleauthorExists(id))
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

        // POST: api/Titleauthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Titleauthor>> PostTitleauthor(Titleauthor titleauthor)
        {
            _context.Titleauthors.Add(titleauthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleauthorExists(titleauthor.AuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleauthor", new { id = titleauthor.AuId }, titleauthor);
        }

        // DELETE: api/Titleauthors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitleauthor(string id)
        {
            var titleauthor = await _context.Titleauthors.FindAsync(id);
            if (titleauthor == null)
            {
                return NotFound();
            }

            _context.Titleauthors.Remove(titleauthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitleauthorExists(string id)
        {
            return _context.Titleauthors.Any(e => e.AuId == id);
        }
    }
}
