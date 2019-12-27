namespace almoxarifado.Domain.Entities
{
    public class UnidadeMedida :Base
    {
        public int UnidadeMedidaId { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}