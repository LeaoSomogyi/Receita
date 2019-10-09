using Microsoft.AspNetCore.Mvc;
using Receita.Domain.Models;
using Receita.Domain.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAsync()
        {
            try
            {
                var usuarios = await _service.GetAllAsync();
                return new OkObjectResult(usuarios);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int id)
        {
            try
            {
                var usuario = await _service.GetByIdAsync(id);
                if (usuario != null)
                {
                    return new OkObjectResult(usuario);    
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostAsync(Usuario usuario)
        {
            try
            {
                var total = await _service.AddAsync(usuario);

                return new OkObjectResult(usuario);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Usuario usuario)
        {
            try
            {
                usuario.Id = id;
                var total = await _service.UpdateAsync(usuario);

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
        public async Task<ActionResult<Usuario>> DeleteAsync(int id)
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
