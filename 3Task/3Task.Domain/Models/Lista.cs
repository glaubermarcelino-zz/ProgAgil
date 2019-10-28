using System;
using System.Collections.Generic;
using System.Text;

namespace _3Task.Domain.Models
{
    [JsonRoot("lists")]
    public class Lista
    {
        [JsonProperty(JsonPropertyName="id")]
        public string IdList { get; set; }

        [JsonProperty(JsonPropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(JsonPropertyName = "closed")]
        public bool Fechado { get; set; }

        [JsonProperty(JsonPropertyName = "idBoard")]
        public string IdQuadro { get; set; }

        [JsonProperty(JsonPropertyName = "pos")]
        public int pos { get; set; }

        [JsonProperty(JsonPropertyName = "subscribed")]
        public bool Inscrito { get; set; }

        [JsonProperty(JsonPropertyName = "softLimit")]
        public int softLimit { get; set; }
        public virtual Quadro Quadros { get; set; }
    }
}
