using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgAgil.Domain.Entities;
using ProgAgil.Repository;

namespace ProgAgil.Domain.Controlers{

[Route("api/[controller]")]
[ApiController]
    public class PalestranteController :ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }
        // GET api/Palestrante
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.ObterTodosPalestrantesAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
        }

          // GET api/Palestrante/5
        [HttpGet("{PalestranteId}")]
        public async Task<IActionResult> Get(int PalestranteId)
        {
            try
            {
                var results = await _repo.ObterPalestrantePorIdAsync(PalestranteId,true);
                if(results==null)return NotFound();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
        }

            // GET api/Palestrante/Glauber
        [HttpGet("{Nome}")]
        public async Task<IActionResult> Get(string Nome)
        {
            try
            {
                var results = await _repo.ObterTodosPalestrantesPorNomeAsync(Nome,true);
                if(results==null)return NotFound();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
        }

        // POST api/Palestrante
        [HttpPost]
        public async Task<IActionResult> Post(Palestrante palestrante)
        {
            try
            {
                _repo.Adicionar(palestrante);

                if(await _repo.SaveChangesAsync()){
                    return Created($"api/palestrante/{palestrante.Id}",palestrante);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
            return BadRequest();
        }

            // PUT api/Palestrante/1
        [HttpPut("{PalestranteId}")]
        public async Task<IActionResult> Put(int PalestranteId,Palestrante palestrante)
        {
            try
            {
                var results = await _repo.ObterPalestrantePorIdAsync(PalestranteId);

                if(results==null)return NotFound();

                _repo.Atualizar(palestrante);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/palestrante/{palestrante.Id}",palestrante);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
            return BadRequest();
        }

        // Delete api/Palestrante/1
        [HttpDelete("{PalestranteId}")]
        public async Task<IActionResult> Delete(int PalestranteId)
        {
            try
            {
                var results = await _repo.ObterPalestrantePorIdAsync(PalestranteId);

                if(results==null)return NotFound();

                _repo.Deletar(results);
                if(await _repo.SaveChangesAsync()){
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
            return BadRequest();
        }
    }
}