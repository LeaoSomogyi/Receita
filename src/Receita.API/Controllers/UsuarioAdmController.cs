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
    public class UsuarioAdmController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public UsuarioAdmController(ReceitaContext context)
        {
            _context = context;
        }
        // GET: api/Receita

        [HttpGet]
        public IEnumerable<UsuarioAdm> Get()
        {
            return _context.UsuarioAdms.AsEnumerable();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioAdm>> Get(int id)
        {
            var itemUsuarioAdm = await _context.UsuarioAdms.FindAsync(id);
            if (itemUsuarioAdm == null)
            {
                return NotFound();
            }

            return itemUsuarioAdm;
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<UsuarioAdm>> Post(UsuarioAdm usuarioAdm)
        {
            _context.UsuarioAdms.Add(usuarioAdm);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = usuarioAdm.IdUsuarioAdm }, usuarioAdm);
        }

        // PUT: api/Receita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioAdm usuarioAdm)
        {
            if (id != usuarioAdm.IdUsuarioAdm)
            {
                return BadRequest();
            }
            _context.Entry(usuarioAdm).State = EntityState.Modified;
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
        public async Task<ActionResult<UsuarioAdm>> Delete(int id)
        {
            var itemUsuario = await _context.UsuarioAdms.FindAsync(id);
            if (itemUsuario == null)
            {
                return NotFound();
            }
            _context.UsuarioAdms.Remove(itemUsuario);
            await _context.SaveChangesAsync();

            return itemUsuario;
        }
    }
}
