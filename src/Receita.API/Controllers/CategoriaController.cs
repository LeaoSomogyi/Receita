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
    public class CategoriaController : ControllerBase
    {

        private readonly ReceitaContext _context;

        public CategoriaController(ReceitaContext context)
        {
            _context = context;
        }
        // GET: api/Categoria

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.AsEnumerable();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var itemReceita = await _context.Categorias.FindAsync(id);
            if (itemReceita == null)
            {
                return NotFound();
            }

            return itemReceita;
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = categoria.IdCategoria }, categoria);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
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

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var itemCategoria = await _context.Categorias.FindAsync(id);
            if (itemCategoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(itemCategoria);
            await _context.SaveChangesAsync();

            return itemCategoria;
        }
    }
}
