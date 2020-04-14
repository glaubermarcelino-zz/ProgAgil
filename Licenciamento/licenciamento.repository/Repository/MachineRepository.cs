using Licenciamento.domain.Entities;
using Licenciamento.repository.Data;
using Licenciamento.repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Licenciamento.repository.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly LicenciamentoContext _context;

        public MachineRepository(LicenciamentoContext context)
        {
            this._context = context;
        }
        public void AddMachine(Machine machine)
        {
            _context.Machines.Add(machine);
        }

        public void DeleteMachine(Machine machine)
        {
            _context.Machines.Remove(machine);
        }

        public async Task<Machine[]> GetMachineAll()
        {
            return await _context.Machines.ToArrayAsync();
        }

        public async Task<Machine> GetMachineById(string id)
        {
            var query = _context.Machines
                        .AsNoTracking()
                        .Where(m => m.chave_mach == id);
            return await query.FirstOrDefaultAsync();
        }

        public bool RegisterMachine(Machine machine)
        {
            //Verifica se a estação já existe
            var result = _context.Machines.Where(x => x.chave_mach == machine.chave_mach);
            //se já existir a estação cadastrada retorna false
            if (result.Count() > 0)
                return false;
            //Adiciona a estação caso não exista
            _context.Machines.Add(machine);
            _context.SaveChanges();
            return true;
        }

        public bool UnLockMachine(Machine machine)
        {
            //Verifica se a estação já existe
            var result = _context.Machines.Where(x => x.chave_mach == machine.chave_mach);
            //se já existir a estação ,faz a verificação se existe restrição na tabela cli_payment
            if (result.Count() > 1)
            {
                if(_context.CliPayment.Where(c=>c.chave_match == machine.chave_mach && c.payment_status == true).ToList().Count>0)
                return false;
            }
            //Sem restrições
            return true;
        }

        public void UpdateMachine(Machine machine)
        {
                _context.Machines.Update(machine);
                _context.SaveChanges();
        }
    }
}
