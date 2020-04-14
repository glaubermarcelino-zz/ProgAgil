using Licenciamento.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Licenciamento.repository.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine[]> GetMachineAll();
        Task<Machine> GetMachineById(string id);
        void AddMachine(Machine machine);
        void DeleteMachine(Machine machine);
        void UpdateMachine(Machine machine);
        bool RegisterMachine(Machine machine);
        bool UnLockMachine(Machine machine);
    }
}
