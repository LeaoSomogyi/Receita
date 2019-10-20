using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Receita.API.Models;
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
        private readonly IMapper _mapper;

        public UsuariosController(IMapper mapper, IUsuarioService service)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<ActionResult<Usuario>> PostAsync(UsuarioModel usuario)
        {
            try
            {
                var mapper = _mapper.Map<Usuario>(usuario);
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
        public async Task<IActionResult> PutAsync(int id, UsuarioModel usuario)
        {
            try
            {
                var mapper = _mapper.Map<Usuario>(usuario);
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
