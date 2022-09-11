using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZwiftyAPI.Data;
using ZwiftyAPI.Models;

namespace ZwiftyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutGoingShipmentsController : ControllerBase
    {
        private readonly ZwiftyAPIContext _context;

        public OutGoingShipmentsController(ZwiftyAPIContext context)
        {
            _context = context;
        }

        // GET: api/OutGoingShipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutGoingShipment>>> GetOutGoingShipment()
        {
          if (_context.OutGoingShipment == null)
          {
              return NotFound();
          }
            return await _context.OutGoingShipment.ToListAsync();
        }

        // GET: api/OutGoingShipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutGoingShipment>> GetOutGoingShipment(int id)
        {
          if (_context.OutGoingShipment == null)
          {
              return NotFound();
          }
            var outGoingShipment = await _context.OutGoingShipment.FindAsync(id);

            if (outGoingShipment == null)
            {
                return NotFound();
            }

            return outGoingShipment;
        }

        // PUT: api/OutGoingShipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutGoingShipment(int id, OutGoingShipment outGoingShipment)
        {
            if (id != outGoingShipment.OutGoingShipmentID)
            {
                return BadRequest();
            }

            _context.Entry(outGoingShipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutGoingShipmentExists(id))
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

        // POST: api/OutGoingShipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OutGoingShipment>> PostOutGoingShipment(OutGoingShipment outGoingShipment)
        {
          if (_context.OutGoingShipment == null)
          {
              return Problem("Entity set 'ZwiftyAPIContext.OutGoingShipment'  is null.");
          }
            _context.OutGoingShipment.Add(outGoingShipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutGoingShipment", new { id = outGoingShipment.OutGoingShipmentID }, outGoingShipment);
        }

        // DELETE: api/OutGoingShipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutGoingShipment(int id)
        {
            if (_context.OutGoingShipment == null)
            {
                return NotFound();
            }
            var outGoingShipment = await _context.OutGoingShipment.FindAsync(id);
            if (outGoingShipment == null)
            {
                return NotFound();
            }

            _context.OutGoingShipment.Remove(outGoingShipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OutGoingShipmentExists(int id)
        {
            return (_context.OutGoingShipment?.Any(e => e.OutGoingShipmentID == id)).GetValueOrDefault();
        }
    }
}
