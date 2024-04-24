using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClockDB.Data;
using ClockDB.Models;

namespace ClockDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogsController : ControllerBase
    {
        private readonly ClockDBContext _context;

        public TimeLogsController(ClockDBContext context)
        {
            _context = context;
        }

        // GET: api/TimeLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeLogs>>> GetTimeLogs()
        {
            return await _context.TimeLogs.ToListAsync();
        }

        // GET: api/TimeLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeLogs>> GetTimeLogs(Guid id)
        {
            var timeLogs = await _context.TimeLogs.FindAsync(id);

            if (timeLogs == null)
            {
                return NotFound();
            }

            return timeLogs;
        }

        // PUT: api/TimeLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeLogs(Guid id, TimeLogs timeLogs)
        {
            if (id != timeLogs.TimeLogsId)
            {
                return BadRequest();
            }

            _context.Entry(timeLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeLogsExists(id))
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

        // POST: api/TimeLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeLogs>> PostTimeLogs(TimeLogs timeLogs)
        {
            _context.TimeLogs.Add(timeLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeLogs", new { id = timeLogs.TimeLogsId }, timeLogs);
        }

        // DELETE: api/TimeLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeLogs(Guid id)
        {
            var timeLogs = await _context.TimeLogs.FindAsync(id);
            if (timeLogs == null)
            {
                return NotFound();
            }

            _context.TimeLogs.Remove(timeLogs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeLogsExists(Guid id)
        {
            return _context.TimeLogs.Any(e => e.TimeLogsId == id);
        }
    }
}
