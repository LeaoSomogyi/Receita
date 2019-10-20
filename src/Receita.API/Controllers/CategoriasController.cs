using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Receita.API.Models;
using Receita.Domain.Models;
using Receita.Domain.Services.Categorias;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriasController(IMapper mapper,ICategoriaService service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Categoria>>> GetAsync()
        {
            try
            {
                var categorias = await _service.GetAllAsync();
                return new OkObjectResult(categorias);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int id)
        {
            try
            {
                var categorias = await _service.GetByIdAsync(id); ;

                if (categorias != null)
                {
                    return new OkObjectResult(categorias);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostAsync([FromBody] CategoriaModel categoria)
        {
            try
            {
                var mapper = _mapper.Map<Categoria>(categoria);
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
        public async Task<IActionResult> PutAsync(int id, [FromBody] CategoriaModel categoria)
        {
            try
            {
                var mapper = _mapper.Map<Categoria>(categoria);
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
        public async Task<ActionResult<Categoria>> DeleteAsync(int id)
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
