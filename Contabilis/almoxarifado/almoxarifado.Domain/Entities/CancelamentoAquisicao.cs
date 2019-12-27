namespace almoxarifado.Domain.Entities
{
    public class CancelamentoAquisicao:Base
    {
        public int CancelamentoAquisicaoId { get; set; }        
        public int AquisicaoId { get; set; }
        public virtual Aquisicao Aquisicao { get; set; }
    }
}