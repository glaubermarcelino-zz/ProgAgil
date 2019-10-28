using System;
using System.Collections.Generic;
using System.Text;

namespace _3Task.Domain.Models
{
    public class QuadroCartao
    {
        public int board { get; set; }
        public int card { get; set; }
        public virtual Cartao Cartao { get; set; }
        public Quadro Quadro { get; set; }
    }
}
