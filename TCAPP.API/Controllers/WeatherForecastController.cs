using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TCAPPContext _contenxt;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TCAPPContext context)
        {
            _logger = logger;
            _contenxt = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("generar")]
        public async Task<IActionResult> GenerarContenido([FromBody] Content content)
        {
            var result = await _contenxt.Contents.AddAsync(content);
            await _contenxt.SaveChangesAsync();
            return Ok(result.Entity);
        }
        [HttpPost("generate-child/{id}")]
        public async Task<IActionResult> GenerateRel(decimal id, [FromBody] Content content)
        {
            var r = _contenxt.Contents.Add(content);
            await _contenxt.SaveChangesAsync();
            var result = await _contenxt.Contents.FindAsync(id);
            result.ChildrenContents.Add(new ParentContent { IdContent = content.Id, IdParentContent = id });
            await _contenxt.SaveChangesAsync();
            return Ok(r.Entity);
        }
        [HttpGet("get-item/{id}")]
        public async Task<IActionResult> GetItem(decimal id)
        {
            var result = await _contenxt.Contents.Select(x => new {
                x.Id,
                x.IdContentType,
                ChildrenContents = x.ChildrenContents.Select(y => new
                {
                    y.IdContent,
                    y.IdParentContent,
                    y.Content
                })
            }).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }
        [HttpGet("get-parent/{id}")]
        public async Task<IActionResult> GeteParent(decimal id)
        {
            var result = await _contenxt.Contents.Select(x => new
            {
                x.Id,
                ParentContent = x.ParentContents.Select(y => new
                {
                    y.IdContent,
                    y.IdParentContent,
                    y.Parent
                })
            }).FirstAsync(x => x.Id == id);
            return Ok(result);
        }
    }
}
