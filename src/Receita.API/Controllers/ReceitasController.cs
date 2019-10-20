using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Receita.API.Models;
using Receita.Domain.Services.Receitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Receita.Domain.Models;

namespace Receita.API.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService _service;
        private readonly IMapper _mapper;

        public ReceitasController(IMapper mapper,IReceitaService service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Model.Receita>>> GetAsync()
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
        public async Task<ActionResult<Model.Receita>> GetByIdAsync(int id)
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
        public async Task<ActionResult<Model.Receita>> GetByCategoriaAsync(int id)
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
        public async Task<ActionResult<Model.Receita>> PostAsync(ReceitaModel receita)
        {
            try
            {
                var mapper = _mapper.Map<Model.Receita>(receita);
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
        public async Task<IActionResult> PutAsync(int id, ReceitaModel receita)
        {
            try
            {
                var mapper = _mapper.Map<Model.Receita>(receita);
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
        public async Task<ActionResult<Model.Receita>> DeleteAsync(int id)
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
