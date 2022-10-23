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
    public class PubInfoesController : ControllerBase
    {
        private readonly pubsContext _context;

        public PubInfoesController(pubsContext context)
        {
            _context = context;
        }

        // GET: api/PubInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PubInfo>>> GetPubInfos()
        {
            return await _context.PubInfos.ToListAsync();
        }

        // GET: api/PubInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PubInfo>> GetPubInfo(string id)
        {
            var pubInfo = await _context.PubInfos.FindAsync(id);

            if (pubInfo == null)
            {
                return NotFound();
            }

            return pubInfo;
        }

        // PUT: api/PubInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPubInfo(string id, PubInfo pubInfo)
        {
            if (id != pubInfo.PubId)
            {
                return BadRequest();
            }

            _context.Entry(pubInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PubInfoExists(id))
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

        // POST: api/PubInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PubInfo>> PostPubInfo(PubInfo pubInfo)
        {
            _context.PubInfos.Add(pubInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PubInfoExists(pubInfo.PubId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPubInfo", new { id = pubInfo.PubId }, pubInfo);
        }

        // DELETE: api/PubInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePubInfo(string id)
        {
            var pubInfo = await _context.PubInfos.FindAsync(id);
            if (pubInfo == null)
            {
                return NotFound();
            }

            _context.PubInfos.Remove(pubInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PubInfoExists(string id)
        {
            return _context.PubInfos.Any(e => e.PubId == id);
        }
    }
}
