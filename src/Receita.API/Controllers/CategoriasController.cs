using Microsoft.AspNetCore.Mvc;
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

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
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
        public async Task<ActionResult<Categoria>> GetAsync(int id)
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
        public async Task<ActionResult<Categoria>> PostAsync(Categoria categoria)
        {
            try
            {
                await _service.AddAsync(categoria);
                return new CreatedResult("", categoria);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Categoria categoria)
        {
            try
            {
                categoria.Id = id;
                var total = await _service.UpdateAsync(categoria);

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
