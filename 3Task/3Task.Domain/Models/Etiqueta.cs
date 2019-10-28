using System;
using System.Collections.Generic;
using System.Text;

namespace _3Task.Domain.Models
{
    public class Etiqueta
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        [ForeignKey("idBoard")]
        public virtual Quadro Quadro { get; set; }
    }
}
