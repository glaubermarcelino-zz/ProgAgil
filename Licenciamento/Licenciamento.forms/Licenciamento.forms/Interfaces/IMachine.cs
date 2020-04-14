using Licenciamento.forms.Entities;
using Refit;
using System.Threading.Tasks;

namespace Licenciamento.forms.Interfaces
{
    public interface IMachine
    {
        [Get("/machine/{id}")]
        Task<Machine> GetMachineId(string id);

        [Get("/machine/{Id}")]
        Task<Machine> GetMachinePermission(string Id);
        string GetMachineIdLocal();

        [Get("/machine/{Id}")]
        Task<Machine> AutenticateMachine(string Id);

        [Post("/machine")]
        Task<Machine> RegisterMachine(Machine machine);

        [Put("/machine/{machineid}")]
        Task<Machine> UpdateMachine(Machine machine,string machineId);

    }
}
