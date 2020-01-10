using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace licenciamento.app.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MachineController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MachineController> _logger;

        public MachineController(ILogger<MachineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Machine> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Machine
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
