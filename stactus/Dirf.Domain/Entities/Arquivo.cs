using System;
using System.IO;

namespace Dirf.Domain.Entities
{
    public class Arquivo
    {
        public int ArquivoId { get; set; }
        public string Nome { get; set; }
        public int ClienteId { get; set; }
        public string Ano { get; set; }
        public Guid GuidFile { get; set; }
        public FileStream arquivo { get; set; }
        public double Tamanho { get; set; }
        public string Caminho { get; set; }
    }
}