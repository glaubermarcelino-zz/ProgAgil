using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgAgil.Api.Dtos;
using ProgAgil.Domain.Entities;
using ProgAgil.Repository;

namespace ProgAgil.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public IMapper _mapper { get; }

        public EventoController(IProAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        //GET api/Evento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _repo.ObterTodosEventosAsync();

                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
        }

        // Upload Files
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fodlerName = Path.Combine("Resources","Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(),fodlerName);

                if(file.Length > 0){
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave,filename.Replace("\""," ").Trim());

                    using(var stream = new FileStream(fullPath,FileMode.Create)){
                        await file.CopyToAsync(stream);
                    }
                }
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível efetuar upload do arquivo!");
            }
        }

        // GET api/Evento/5
        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var evento = await _repo.ObterEventoPorIdAsync(EventoId, true);

                var result = _mapper.Map<EventoDto>(evento);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, $"Evento Nº {EventoId} não localizado");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }

        // GET api/Evento/nassau
        [HttpGet("Tema/{Tema}")]
        public async Task<IActionResult> GetTema(string Tema)
        {
            try
            {
                var evento = await _repo.ObterTodosEventosPorTemaAsync(Tema, true);
                var results = _mapper.Map<EventoDto[]>(evento);
                if (results != null)
                {
                    return Ok(results);
                }
                else
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, $"Tema '{Tema}' não localizado");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }

        // POST api/Evento
        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _repo.Adicionar(evento);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/Evento/{evento.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados " + e.Message);
            }

            return StatusCode(StatusCodes.Status403Forbidden, $"Ocorreu um erro ao inserir {model}");
        }

        // PUT api/Evento/5
        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, EventoDto model)
        {
            try
            {
                var result = await _repo.ObterEventoPorIdAsync(EventoId);
                if (result == null) return NotFound();

                //Efetua o mapeamento das alterações de acordo com o item buscado
                _mapper.Map(model,result);

                _repo.Atualizar(result);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/Evento/{model.Id}", _mapper.Map<EventoDto>(result));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
            return BadRequest();
        }

        // DELETE api/Evento/5
        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repo.ObterEventoPorIdAsync(EventoId);
                if (evento == null) return NotFound();

                _repo.Deletar(evento);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
            return BadRequest();
        }
    }
}