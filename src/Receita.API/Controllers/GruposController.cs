using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using Receita.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/grupos")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public GruposController(ReceitaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Grupo>> Get()
        {
            try
            {
                var grupos = _context.Grupos.AsEnumerable();
                return new OkObjectResult(grupos);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> Get(int id)
        {
            try
            {
                var grupo = await _context.Grupos.FindAsync(id);
                if (grupo != null)
                {
                    return new OkObjectResult(grupo);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Grupo>> Post(Grupo papel)
        {
            try
            {
                _context.Grupos.Add(papel);
                await _context.SaveChangesAsync();
                return new CreatedResult("", papel);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Grupo grupo)
        {
            try
            {
                grupo.Id = id;
                _context.Update(grupo);
                _context.Entry(grupo).State = EntityState.Modified;
                var total = await _context.SaveChangesAsync();

                if (total > 0) 
                {
                    return new OkResult();
                } 
                
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Grupo>> Delete(int id)
        {
            try
            {
                var grupo = await _context.Grupos.FindAsync(id);
                if (grupo != null)
                {
                    _context.Grupos.Remove(grupo);
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
