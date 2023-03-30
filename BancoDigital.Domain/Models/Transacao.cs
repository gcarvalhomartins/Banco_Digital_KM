using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Models
{
    public class Transacao : Conta
    {
        public decimal Deposito { get; set; }
        public decimal Pagamento { get; set; }
        public decimal Transferencia { get; set; }
    }
}
