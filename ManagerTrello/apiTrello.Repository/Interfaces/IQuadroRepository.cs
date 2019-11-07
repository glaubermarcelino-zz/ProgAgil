using apiTrello.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiTrello.Repository.Interfaces
{
    public interface IQuadroRepository
    {
        Task<List<Quadro>> GetAll();
        Task<Quadro> GetByName(string name);
        Task<Quadro> GetById(string idQuadro);
    }
}
