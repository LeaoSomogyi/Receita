using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using Receita.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PapelController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public PapelController(ReceitaContext context)
        {
            _context = context;
        }
        // GET: api/Receita

        [HttpGet]
        public IEnumerable<Papel> Get()
        {
            return _context.Papeis.AsEnumerable();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Papel>> Get(int id)
        {
            var itemPapel = await _context.Papeis.FindAsync(id);
            if (itemPapel == null)
            {
                return NotFound();
            }

            return itemPapel;
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Papel papel)
        {
            _context.Papeis.Add(papel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = papel.IdPapel }, papel);
        }

        // PUT: api/Receita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Papel papel)
        {
            if (id != papel.IdPapel)
            {
                return BadRequest();
            }
            _context.Entry(papel).State = EntityState.Modified;
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
        public async Task<ActionResult<Papel>> Delete(int id)
        {
            var itemPapel = await _context.Papeis.FindAsync(id);
            if (itemPapel == null)
            {
                return NotFound();
            }
            _context.Papeis.Remove(itemPapel);
            await _context.SaveChangesAsync();

            return itemPapel;
        }
    }
}
