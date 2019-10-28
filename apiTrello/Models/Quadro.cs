using Newtonsoft.Json;

namespace apiTrello.Models
{
    public class Quadro
    {
        [JsonProperty("id")]
        public string idQuadro{get;set;}
        [JsonProperty("name")]
        public string Nome{get;set;}
        [JsonProperty("url")]
        public string Url{get;set;}
    }
}