﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using Receita.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receita.API.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public StatusController(ReceitaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Status>> Get()
        {
            try
            {
                var status = _context.Status.AsEnumerable();
                return new OkObjectResult(status);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            try
            {
                var status = await _context.Status.FindAsync(id);
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
        public async Task<ActionResult<Status>> Post(Status status)
        {
            try
            {
                _context.Status.Add(status);
                await _context.SaveChangesAsync();

                return new CreatedResult("", status);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Status status)
        {
            try
            {
                status.Id = id;
                _context.Update(status);
                _context.Entry(status).State = EntityState.Modified;
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
        public async Task<ActionResult<Status>> Delete(int id)
        {
            try
            {
                var status = await _context.Status.FindAsync(id);
                if (status != null)
                {
                    _context.Status.Remove(status);
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
