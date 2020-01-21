using System;
namespace M2AIntegracao.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId{get;set;}
        string Cnpj { get; set; }
        int CodProduto { get; set; }
        int CodProdutoExportacao { get; set; }
        string Produto { get; set; }
        string Descricao { get; set; }
        string GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        DateTime DataAlteracao { get; set; }
        DateTime DataDesativacao { get; set; }
        bool fl_migracao { get; set; }
        int UnidadeMedidaId { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        DateTime DataCadastro { get; set; }
        bool fl_generico { get; set; }
    }
}