using System;

namespace almoxarifado.Domain.Entities
{
    public enum TipoAquisicao
    {
        AQUISICAO       = 1,
        ENTRADA_DIRETA  = 2,
        DOACAO          = 3,
        DACAO          = 4,
        ADJUDICACAO      = 5,
        INVENTARIO_POR_AQUISICAO      = 6,
        TRANSFERENCIA_ENTRE_ORGAOS = 7

    }
    public class Aquisicao:Base
    {
        public int AquisicaoId { get; set; }
        public TipoAquisicao TipoAquisicao { get; set; }
        public DateTime DataAquisicao { get; set; }
        public int? AlmoxarifadoId { get; set; }
        public virtual Almoxarifado Almoxarifado{get;set;}
        public int CentroCustoId { get; set; }
        public virtual CentroCusto CentroCusto { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor{ get; set; }
        public int? EmpenhoId { get; set; }
        public virtual Empenho Empenho { get; set; }
        public int? AnoEmpenho { get; set; }
        public bool RestosAPagar { get; set; }
        

    }
}