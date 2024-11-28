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
    public class VuelosController : ControllerBase
    {
        private readonly AerolineaContext _context;

        public VuelosController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: api/Vuelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelos>>> GetVuelos()
        {
            return await _context.Vuelos.ToListAsync();
        }

        // GET: api/Vuelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelos>> GetVuelos(int id)
        {
            var vuelos = await _context.Vuelos.FindAsync(id);

            if (vuelos == null)
            {
                return NotFound();
            }

            return vuelos;
        }

        // PUT: api/Vuelos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelos(int id, Vuelos vuelos)
        {
            if (id != vuelos.ID_vuelo)
            {
                return BadRequest();
            }

            _context.Entry(vuelos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VuelosExists(id))
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

        // POST: api/Vuelos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vuelos>> PostVuelos(Vuelos vuelos)
        {
            _context.Vuelos.Add(vuelos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVuelos", new { id = vuelos.ID_vuelo }, vuelos);
        }

        // DELETE: api/Vuelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelos(int id)
        {
            var vuelos = await _context.Vuelos.FindAsync(id);
            if (vuelos == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VuelosExists(int id)
        {
            return _context.Vuelos.Any(e => e.ID_vuelo == id);
        }
    }
}
