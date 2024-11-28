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
    public class AvionesController : ControllerBase
    {
        private readonly AerolineaContext _context;

        public AvionesController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: api/Aviones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aviones>>> GetAviones()
        {
            return await _context.Aviones.ToListAsync();
        }

        // GET: api/Aviones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aviones>> GetAviones(int id)
        {
            var aviones = await _context.Aviones.FindAsync(id);

            if (aviones == null)
            {
                return NotFound();
            }

            return aviones;
        }

        // PUT: api/Aviones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAviones(int id, Aviones aviones)
        {
            if (id != aviones.ID_Avion)
            {
                return BadRequest();
            }

            _context.Entry(aviones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionesExists(id))
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

        // POST: api/Aviones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aviones>> PostAviones(Aviones aviones)
        {
            _context.Aviones.Add(aviones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAviones", new { id = aviones.ID_Avion }, aviones);
        }

        // DELETE: api/Aviones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAviones(int id)
        {
            var aviones = await _context.Aviones.FindAsync(id);
            if (aviones == null)
            {
                return NotFound();
            }

            _context.Aviones.Remove(aviones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvionesExists(int id)
        {
            return _context.Aviones.Any(e => e.ID_Avion == id);
        }
    }
}
