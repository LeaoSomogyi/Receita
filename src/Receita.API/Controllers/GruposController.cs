using Microsoft.AspNetCore.Mvc;
using Receita.Domain.Models;
using Receita.Domain.Services.Grupos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/grupos")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoService _service;

        public GruposController(IGrupoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Grupo>>> GetAsync()
        {
            try
            {
                var grupos = await _service.GetAllAsync();
                return new OkObjectResult(grupos);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetByIdAsync(int id)
        {
            try
            {
                var grupo = await _service.GetByIdAsync(id);
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
        public async Task<ActionResult<Grupo>> PostAsync(Grupo grupo)
        {
            try
            {
                var total = await _service.AddAsync(grupo);
                if (total > 0)
                {
                    return new CreatedResult("", grupo);
                }
                return new AcceptedResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, Grupo grupo)
        {
            try
            {
                grupo.Id = id;
                var total = await _service.UpdateAsync(grupo);

                if (total > 0) 
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Grupo>> DeleteAsync(int id)
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
