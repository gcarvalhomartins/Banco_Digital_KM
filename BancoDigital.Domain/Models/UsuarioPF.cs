using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Models
{
    public class UsuarioPF : Usuario
    {
        public string? CPF { get; set; }
        public int Idade { get; set; }

    }
}
