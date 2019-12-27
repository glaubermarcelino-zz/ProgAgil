using System;

namespace almoxarifado.Domain.Entities
{
    public class NotaFiscal:Base
    {
        public int NotaFiscalId { get; set; }
        public string ChaveAcesso { get; set; }
        public string Numero { get; set; }
        public double Valor { get; set; }
        public string Uf{ get; set; }
        public string Serie { get; set; }
        public DateTime DataEmissao { get; set; }
        public int FornecedorId { get; set; }
    }
}