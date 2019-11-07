using apiTrello.Domain;
using apiTrello.Repository.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace apiTrello.Repository.Repository
{
    public class QuadroRepository : IQuadroRepository
    {
        public async Task<List<Quadro>> GetAll()
        {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(TrelloConfig.GetEndPoint())
                                                .ConfigureAwait(false);
                    if (response == null) return null;
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response);
                }
        }

        public async Task<Quadro> GetById(string idQuadro)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(TrelloConfig.GetEndPoint())
                                            .ConfigureAwait(false);
                if (response == null) return null;

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response)
                                                        .Where(q => q.idQuadro == idQuadro)
                                                        .FirstOrDefault();
                return result;
            }
        }

        public async Task<Quadro> GetByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(TrelloConfig.GetEndPoint())
                                            .ConfigureAwait(false);
                if (response == null) return null;

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response)
                                                        .Where(q => q.Nome == name)
                                                        .FirstOrDefault();
                if (result == null) return null;

                return result;
            }
        }
    }
}
