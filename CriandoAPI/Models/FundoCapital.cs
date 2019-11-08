using System;

namespace CriandoAPI.Models
{
    public class FundoCapital
    {
        public FundoCapital()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Double ValorAtual { get; set; }
        public Double ValorNecessario { get; set; }
        public DateTime? DataResgate { get; set; }
    }
}