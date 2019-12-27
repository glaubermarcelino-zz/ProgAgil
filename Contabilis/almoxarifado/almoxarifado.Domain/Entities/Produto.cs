using System;

namespace almoxarifado.Domain.Entities
{
    public class Produto :Base
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int UnidadeMedidaId { get; set; }
        public virtual UnidadeMedida UnidadeMedida{ get; set; }
        public int CdGrupo { get; set; }
        public virtual Grupo Grupo{get;set;}
        public DateTime DataCadastro { get; set; }
        public DateTime? DataDesativacao { get; set; }

}