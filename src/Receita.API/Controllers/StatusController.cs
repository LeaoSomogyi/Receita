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
    public class StatusController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public StatusController(ReceitaContext context)
        {
            _context = context;
        }
        // GET: api/Receita

        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _context.Status.AsEnumerable();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            var itemStatus = await _context.Status.FindAsync(id);
            if (itemStatus == null)
            {
                return NotFound();
            }

            return itemStatus;
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Status>> Post(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = status.IdStatus }, status);
        }

        // PUT: api/Receita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Status status)
        {
            if (id != status.IdStatus)
            {
                return BadRequest();
            }
            _context.Entry(status).State = EntityState.Modified;
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
        public async Task<ActionResult<Status>> Delete(int id)
        {
            var itemStatus = await _context.Status.FindAsync(id);
            if (itemStatus == null)
            {
                return NotFound();
            }
            _context.Status.Remove(itemStatus);
            await _context.SaveChangesAsync();

            return itemStatus;
        }
    }
}
