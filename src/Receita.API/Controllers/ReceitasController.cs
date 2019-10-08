using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Receita.Domain.Model;

namespace Receita.API.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public ReceitasController(ReceitaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.Receita>> Get()
        {
            try
            {
                var receita = _context.Receitas.AsEnumerable();
                return new OkObjectResult(receita);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Receita>> Get(int id)
        {
            try
            {
                var receita = await _context.Receitas.FindAsync(id);
                if (receita != null)
                {
                    return new OkObjectResult(receita);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Models.Receita>> Post(Models.Receita receita)
        {
            try
            {
                _context.Receitas.Add(receita);
                await _context.SaveChangesAsync();

                return new CreatedResult("", receita);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Models.Receita receita)
        {
            try
            {
                receita.Id = id;
                _context.Update(receita);
                _context.Entry(receita).State = EntityState.Modified;
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
        public async Task<ActionResult<Models.Receita>> Delete(int id)
        {
            try
            {
                var receita = await _context.Receitas.FindAsync(id);
                if (receita != null)
                {
                    _context.Receitas.Remove(receita);
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
