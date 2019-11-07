using apiTrello.Domain;
using apiTrello.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace apiTrello.Repository.Repository
{
    public class QuadroRepository : IQuadroRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClient client { get; set; }
        public QuadroRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("trello");
        }
        public async Task<List<Quadro>> GetAll()
        {
            var response = await client.GetStringAsync("boards?field=name,id,url")
                                        .ConfigureAwait(false);
            if (response == null) return null;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response);
        }

        public async Task<Quadro> GetById(string idQuadro)
        {

            var response = await client.GetStringAsync("/members/me/boards/")
                                        .ConfigureAwait(false);
            if (response == null) return null;

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response)
                                                    .Where(q => q.idQuadro == idQuadro)
                                                    .FirstOrDefault();
            return result;
        }

        public async Task<Quadro> GetByName(string name)
        {


            var response = await client.GetStringAsync("/members/me/boards/")
                              .ConfigureAwait(false);
            if (response == null) return null;
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quadro>>(response)
                                                    .Where(q => q.Nome.ToLower() == name.ToLower())
                                                    .FirstOrDefault();
            if (result == null) return null;
            return result;
        }
    }
}
