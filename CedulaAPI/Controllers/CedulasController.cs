using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CedulaAPI.Models;

namespace CedulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CedulasController : ControllerBase
    {
        private readonly ProyectoMobileContext _context;

        public CedulasController(ProyectoMobileContext context)
        {
            _context = context;
        }

        // GET: api/Cedulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cedula>>> GetCedulas()
        {
          if (_context.Cedulas == null)
          {
              return NotFound();
          }
            return await _context.Cedulas.ToListAsync();
        }

        // GET: api/Cedulas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cedula>> GetCedula(string id)
        {
          if (_context.Cedulas == null)
          {
              return NotFound();
          }
            var cedula = await _context.Cedulas.FindAsync(id);

            if (cedula == null)
            {
                return NotFound();
            }

            return cedula;
        }

        // PUT: api/Cedulas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCedula(string id, Cedula cedula)
        {
            if (id != cedula.NumeroCedula)
            {
                return BadRequest();
            }

            _context.Entry(cedula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CedulaExists(id))
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

        // POST: api/Cedulas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cedula>> PostCedula(Cedula cedula)
        {
          if (_context.Cedulas == null)
          {
              return Problem("Entity set 'ProyectoMobileContext.Cedulas'  is null.");
          }
            _context.Cedulas.Add(cedula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CedulaExists(cedula.NumeroCedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCedula", new { id = cedula.NumeroCedula }, cedula);
        }

        // DELETE: api/Cedulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCedula(string id)
        {
            if (_context.Cedulas == null)
            {
                return NotFound();
            }
            var cedula = await _context.Cedulas.FindAsync(id);
            if (cedula == null)
            {
                return NotFound();
            }

            _context.Cedulas.Remove(cedula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CedulaExists(string id)
        {
            return (_context.Cedulas?.Any(e => e.NumeroCedula == id)).GetValueOrDefault();
        }
    }
}
