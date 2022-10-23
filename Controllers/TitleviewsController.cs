using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIpub.Data;
using WebAPIpub.Models;

namespace WebAPIpub.Controllers  //This is a view so removed Inset, Update and Delete. Check why this view is created in the first place.
{                                   //Views are fast way to make controller out of it for data fetching joins particularly. Can deliver fast to FrontEnd using this EF power tools and Visual Studio add Controller API using Entity Framework
    [Route("api/[controller]")]
    [ApiController]
    public class TitleviewsController : ControllerBase
    {
        private readonly pubsContext _context;

        public TitleviewsController(pubsContext context)
        {
            _context = context;
        }

        // GET: api/Titleviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titleview>>> GetTitleviews()
        {
            return await _context.Titleviews.ToListAsync();
        }

        // GET: api/Titleviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titleview>> GetTitleview(string id)
        {
            var titleview = await _context.Titleviews.FindAsync(id);

            if (titleview == null)
            {
                return NotFound();
            }

            return titleview;
        }

        private bool TitleviewExists(string id)
        {
            return _context.Titleviews.Any(e => e.PubId == id);
        }
    }
}
