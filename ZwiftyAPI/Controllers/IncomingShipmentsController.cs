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
    public class IncomingShipmentsController : ControllerBase
    {
        private readonly ZwiftyAPIContext _context;

        public IncomingShipmentsController(ZwiftyAPIContext context)
        {
            _context = context;
        }

        // GET: api/IncomingShipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomingShipment>>> GetIncomingShipment()
        {
          if (_context.IncomingShipment == null)
          {
              return NotFound();
          }
            return await _context.IncomingShipment.ToListAsync();
        }

        // GET: api/IncomingShipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncomingShipment>> GetIncomingShipment(int id)
        {
          if (_context.IncomingShipment == null)
          {
              return NotFound();
          }
            var incomingShipment = await _context.IncomingShipment.FindAsync(id);

            if (incomingShipment == null)
            {
                return NotFound();
            }

            return incomingShipment;
        }

        // PUT: api/IncomingShipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncomingShipment(int id, IncomingShipment incomingShipment)
        {
            if (id != incomingShipment.IncomingShipmentID)
            {
                return BadRequest();
            }

            _context.Entry(incomingShipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomingShipmentExists(id))
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

        // POST: api/IncomingShipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncomingShipment>> PostIncomingShipment(IncomingShipment incomingShipment)
        {
            IncomingShipment formatShipment = new IncomingShipment();
            formatShipment.IncomingShipmentID = incomingShipment.IncomingShipmentID;
            formatShipment.ProductID = incomingShipment.ProductID;
            formatShipment.Quantity = incomingShipment.Quantity;
            formatShipment.TotalCost = incomingShipment.TotalCost;
            formatShipment.DateRecieved = incomingShipment.DateRecieved; 
            formatShipment.OrderNumber = incomingShipment.OrderNumber;
          if (_context.IncomingShipment == null)
          {
              return Problem("Entity set 'ZwiftyAPIContext.IncomingShipment'  is null.");
          }
            _context.IncomingShipment.Add(incomingShipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncomingShipment", new { id = incomingShipment.IncomingShipmentID }, incomingShipment);
        }

        // DELETE: api/IncomingShipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncomingShipment(int id)
        {
            if (_context.IncomingShipment == null)
            {
                return NotFound();
            }
            var incomingShipment = await _context.IncomingShipment.FindAsync(id);
            if (incomingShipment == null)
            {
                return NotFound();
            }

            _context.IncomingShipment.Remove(incomingShipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomingShipmentExists(int id)
        {
            return (_context.IncomingShipment?.Any(e => e.IncomingShipmentID == id)).GetValueOrDefault();
        }
    }
}
