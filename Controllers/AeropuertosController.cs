using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AreolineaAPI.Models;

namespace AreolineaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeropuertosController : ControllerBase
    {
        private readonly AerolineaContext _context;

        public AeropuertosController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: api/Aeropuertos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeropuertos>>> GetAeropuertos()
        {
            return await _context.Aeropuertos.ToListAsync();
        }

        // GET: api/Aeropuertos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeropuertos>> GetAeropuertos(int id)
        {
            var aeropuertos = await _context.Aeropuertos.FindAsync(id);

            if (aeropuertos == null)
            {
                return NotFound();
            }

            return aeropuertos;
        }

        // PUT: api/Aeropuertos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeropuertos(int id, Aeropuertos aeropuertos)
        {
            if (id != aeropuertos.ID_Aeropuerto)
            {
                return BadRequest(); 
            }

            _context.Entry(aeropuertos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeropuertosExists(id))
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

        // POST: api/Aeropuertos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeropuertos>> PostAeropuertos(Aeropuertos aeropuertos)
        {
            _context.Aeropuertos.Add(aeropuertos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeropuertos", new { id = aeropuertos.ID_Aeropuerto }, aeropuertos);
        }

        // DELETE: api/Aeropuertos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeropuertos(int id)
        {
            var aeropuertos = await _context.Aeropuertos.FindAsync(id);
            if (aeropuertos == null)
            {
                return NotFound();
            }

            _context.Aeropuertos.Remove(aeropuertos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeropuertosExists(int id)
        {
            return _context.Aeropuertos.Any(e => e.ID_Aeropuerto == id);
        }
    }
}
