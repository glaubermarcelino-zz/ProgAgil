using System.Collections.Generic;

namespace almoxarifado.Domain.Entities
{
    public class Almoxarifado:Base
    {
        public int AlmoxarifadoId { get; set; }
        public string Nome { get; set; }
        public int CdGrupo { get; set; }
        public virtual List<Grupo> Grupos {get;set;}
    }
}