using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuelManagerApi.Models;

namespace FuelManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsumosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Consumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumo>>> GetConsumos()
        {
            return await _context.Consumos.ToListAsync();
        }

        // GET: api/Consumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumo>> GetConsumo(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);

            if (consumo == null)
            {
                return NotFound();
            }

            return consumo;
        }

        // PUT: api/Consumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumo(int id, Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoExists(id))
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

        // POST: api/Consumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consumo>> PostConsumo(Consumo consumo)
        {
            _context.Consumos.Add(consumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumo", new { id = consumo.Id }, consumo);
        }

        // DELETE: api/Consumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumo(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }

            _context.Consumos.Remove(consumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumos.Any(e => e.Id == id);
        }
    }
}