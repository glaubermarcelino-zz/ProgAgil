using System;
using System.Collections.Generic;
using System.Text;

namespace Licenciamento.domain.Entities
{
    public class CliPayment
    {
        public int CliPaymentId { get; set; }
        public int id_cliente { get; set; }
        public string chave_match { get; set; }
        public bool payment_status { get; set; }
        public DateTime DatePayment { get; set; }
    }
}
