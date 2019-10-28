using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using apiTrello._shared;
using apiTrello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiTrello.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuadroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(TrelloConfig.GetEndPoint())
                                            .ConfigureAwait(false);
                if(response == null) return BadRequest();
                return Ok(Newtonsoft.Json.JsonConvert
                                    .DeserializeObject<List<Quadro>>(response));
           }
        }

         [HttpGet("{idQuadro}")]
        public async Task<IActionResult> Get(string idQuadro)
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(TrelloConfig.GetEndPoint())
                                            .ConfigureAwait(false);
                if(response == null) return BadRequest();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response)
                                                        .Where(q=>q.idQuadro == idQuadro)
                                                        .FirstOrDefault();
                if(result == null) return NotFound();

                return Ok(result);
           }
        }
        
    }
}