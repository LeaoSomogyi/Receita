using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Receita.Domain.Model;

namespace Receita.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public ReceitaController(ReceitaContext context)
        {
            _context = context;
        }
        // GET: api/Receita

        [HttpGet]
        public IEnumerable<Models.Receita> Get()
        {
            return _context.Receitas.AsEnumerable();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Receita>> Get(int id)
        {
            var itemReceita = await _context.Receitas.FindAsync(id);
            if (itemReceita == null)
            {
                return NotFound();
            }

            return itemReceita;
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Models.Receita>> Post(Models.Receita receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = receita.idReceita }, receita);
        }

        // PUT: api/Receita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Models.Receita receita)
        {
            if (id != receita.idReceita)
            {
                return BadRequest();
            }
            _context.Entry(receita).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Receita>> Delete(int id)
        {
            var itemReceita = await _context.Receitas.FindAsync(id);
            if (itemReceita == null)
            {
                return NotFound();
            }
            _context.Receitas.Remove(itemReceita);
            await _context.SaveChangesAsync();

            return itemReceita;
        }
    }
}
