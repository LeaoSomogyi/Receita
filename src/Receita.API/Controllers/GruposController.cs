using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Receita.API.Models;
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
        private readonly IMapper _mapper;

        public GruposController(IMapper mapper,IGrupoService service)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<ActionResult<Grupo>> PostAsync(GrupoModel grupo)
        {
            try
            {
                var mapper = _mapper.Map<Grupo>(grupo);
                var total = await _service.AddAsync(mapper);
                if (total > 0)
                {
                    return new CreatedResult("", mapper);
                }
                return new AcceptedResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, GrupoModel grupo)
        {
            try
            {
                var mapper = _mapper.Map<Grupo>(grupo);
                mapper.Id = id;
                var total = await _service.UpdateAsync(mapper);

                if (total > 0) 
                {
                    return new OkObjectResult(mapper);
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
