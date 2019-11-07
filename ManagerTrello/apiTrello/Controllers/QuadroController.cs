using apiTrello._shared;
using apiTrello.Domain;
using apiTrello.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace apiTrello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuadroController : ControllerBase
    {
        public IQuadroRepository _repository { get; set; }
        public QuadroController(IQuadroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAll();
            return Ok(result);
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