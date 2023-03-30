using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int NumeroDaConta { get; set; }
        public decimal Saldo { get; set; }

    }
}
