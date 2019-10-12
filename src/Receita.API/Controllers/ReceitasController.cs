using Microsoft.AspNetCore.Mvc;
using Receita.Domain.Services.Receitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Receita.Domain.Models;

namespace Receita.API.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService _service;

        public ReceitasController(IReceitaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Models.Receita>>> GetAsync()
        {
            try
            {
                var receitas = await _service.GetAllAsync();
                return new OkObjectResult(receitas);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Receita>> GetByIdAsync(int id)
        {
            try
            {
                var receita = await _service.GetByIdAsync(id);
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

        [HttpGet]
        [Route("categoria/{id}")]
        public async Task<ActionResult<Models.Receita>> GetByCategoriaAsync(int id)
        {
            try
            {
                var receitas = await _service.GetPorCategoriaAsync(id);

                if (receitas.Count() > 0)
                {
                    return new OkObjectResult(receitas);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Models.Receita>> PostAsync(Models.Receita receita)
        {
            try
            {
                var total = await _service.AddAsync(receita);
                if (total > 0)
                {
                    return new CreatedResult("", receita);
                }
                return new AcceptedResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Models.Receita receita)
        {
            try
            {
                receita.Id = id;
                var total = await _service.UpdateAsync(receita);

                if (total > 0)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Receita>> DeleteAsync(int id)
        {
            try
            {
                var total = await _service.RemoveAsync(id);
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
    }
}
