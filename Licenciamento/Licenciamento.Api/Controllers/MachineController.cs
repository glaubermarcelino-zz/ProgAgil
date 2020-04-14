using Licenciamento.domain.Entities;
using Licenciamento.repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Licenciamento.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly ILogger<MachineController> _logger;
        private readonly IMachineRepository _repository;

        public MachineController(ILogger<MachineController> logger,IMachineRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{machineid}")]
        public async Task<IActionResult> AutorizeMachine(string machineid)
        {
            var retorno = await _repository.GetMachineById(machineid);
            if (retorno is null) return NotFound($"Identificação não encontrada {machineid}");
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult AddMachine(Machine machine)
        {
            bool retorno = _repository.RegisterMachine(machine);
            if (retorno==false)  
                return Ok(machine); ;
            return Created($"/api/v1/machine/{machine.chave_mach}", machine );
        }

        [HttpPost("{machineid}")]
        public async Task<IActionResult> UnLockMachine(string machineid, Machine machine)
        {
            var machineReturn = await _repository.GetMachineById(machineid);
            if (machineReturn is null) return NotFound();

            machine.chave_mach = machineReturn.chave_mach;
            machine.id_mach = machineReturn.id_mach;

            bool retorno = _repository.UnLockMachine(machine);
            if (retorno == false)
                return BadRequest(machine); ;
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusMachine(string id, Machine machine)
        {
            //Busca pela estação antes de atualiza
            var machineResult = await _repository.GetMachineById(id);
            //Se não existir retorna não encontrado
            if (machineResult == null) return NotFound();

            //Associando as chaves para atualização dos registros
            machine.chave_mach = machineResult.chave_mach;
            machine.id_mach = machineResult.id_mach;

            //Se existir atualiza as informações no banco de dados
            _repository.UpdateMachine(machine);
            return Created($"/api/v1/machine/{machine.chave_mach}", machine);
        }

    }
}