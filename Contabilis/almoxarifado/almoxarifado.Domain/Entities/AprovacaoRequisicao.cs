namespace almoxarifado.Domain.Entities
{
    public class AprovacaoRequisicao:Base
    {
        public int AprovacaoRequisicaoId { get; set; }
        public int RequisicaoId { get; set; }    
        public virtual Requisicao Requisicao { get; set; }    
    }
}