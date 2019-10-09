using Microsoft.AspNetCore.Mvc;
using Receita.Domain.Models;
using Receita.Domain.Services.Status;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Status>>> GetAsync()
        {
            try
            {
                var status = await _service.GetAllAsync();
                return new OkObjectResult(status);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetByIdAsync(int id)
        {
            try
            {
                var status = await _service.GetByIdAsync(id);
                if (status != null)
                {
                    return new OkObjectResult(status);
                }

                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Status>> PostAsync(Status status)
        {
            try
            {
                await _service.AddAsync(status);

                return new CreatedResult("", status);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Status status)
        {
            try
            {
                status.Id = id;
                var total = await _service.UpdateAsync(status);

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
        public async Task<ActionResult<Status>> DeleteAsync(int id)
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
