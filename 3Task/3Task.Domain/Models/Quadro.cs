namespace _3Task.Domain.Models
{
    //Boards
    //[JsonRoot("boards")]
    public class Quadro
    {
        //[JsonProperty(PropertyName = "id"]
        public string IdQuadro { get; set; }
        //[JsonProperty(PropertyName = "name"]
        public string Nome { get; set; }
        //[JsonProperty(PropertyName = "url"]
        public string Url { get; set; }

    }
}
