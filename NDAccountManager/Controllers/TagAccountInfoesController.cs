using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NDAccountManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagAccountInfoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TagAccountInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TagAccountInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagAccountInfo>>> GetTagAccountInfos()
        {
            return await _context.TagAccountInfos.ToListAsync();
        }

        // GET: api/TagAccountInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagAccountInfo>> GetTagAccountInfo(int id)
        {
            var tagAccountInfo = await _context.TagAccountInfos.FindAsync(id);

            if (tagAccountInfo == null)
            {
                return NotFound();
            }

            return tagAccountInfo;
        }

        // PUT: api/TagAccountInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagAccountInfo(int id, TagAccountInfo tagAccountInfo)
        {
            if (id != tagAccountInfo.TagId)
            {
                return BadRequest();
            }

            _context.Entry(tagAccountInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagAccountInfoExists(id))
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

        // POST: api/TagAccountInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagAccountInfo>> PostTagAccountInfo(TagAccountInfo tagAccountInfo)
        {
            _context.TagAccountInfos.Add(tagAccountInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TagAccountInfoExists(tagAccountInfo.TagId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTagAccountInfo", new { id = tagAccountInfo.TagId }, tagAccountInfo);
        }

        // DELETE: api/TagAccountInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagAccountInfo(int id)
        {
            var tagAccountInfo = await _context.TagAccountInfos.FindAsync(id);
            if (tagAccountInfo == null)
            {
                return NotFound();
            }

            _context.TagAccountInfos.Remove(tagAccountInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagAccountInfoExists(int id)
        {
            return _context.TagAccountInfos.Any(e => e.TagId == id);
        }
    }
}
