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
    public class PilotosController : ControllerBase
    {
        private readonly AerolineaContext _context;

        public PilotosController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: api/Pilotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pilotos>>> GetPilotos()
        {
            return await _context.Pilotos.ToListAsync();
        }

        // GET: api/Pilotos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pilotos>> GetPilotos(int id)
        {
            var pilotos = await _context.Pilotos.FindAsync(id);

            if (pilotos == null)
            {
                return NotFound();
            }

            return pilotos;
        }

        // PUT: api/Pilotos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPilotos(int id, Pilotos pilotos)
        {
            if (id != pilotos.ID_Piloto)
            {
                return BadRequest();
            }

            _context.Entry(pilotos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotosExists(id))
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

        // POST: api/Pilotos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pilotos>> PostPilotos(Pilotos pilotos)
        {
            _context.Pilotos.Add(pilotos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPilotos", new { id = pilotos.ID_Piloto }, pilotos);
        }

        // DELETE: api/Pilotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePilotos(int id)
        {
            var pilotos = await _context.Pilotos.FindAsync(id);
            if (pilotos == null)
            {
                return NotFound();
            }

            _context.Pilotos.Remove(pilotos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PilotosExists(int id)
        {
            return _context.Pilotos.Any(e => e.ID_Piloto == id);
        }
    }
}
