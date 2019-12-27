namespace almoxarifado.Domain.Entities
{
    public class ItemAquisicao:Base
    {
        public int ItemAquisicaoId { get; set; }
        public int AquisicaoId { get; set; }
        public virtual Aquisicao Aquisicao { get; set; }
        public int ProdutoId { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double? ValorRateio { get; set; }
        public string Lote { get; set; }
    }
}