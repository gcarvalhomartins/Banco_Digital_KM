using BancoDigital.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Repository
{
    public class BancoDigitalDBContext : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPF> UsuarioPFS { get; set; }
        public DbSet<UsuarioPJ> UsuarioPJS { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder constructor)
        {
            string connectionString = "BancoDigital: Server./;DataBase=ProjetoBanco;User Id=BancoDigital;Password =12345";
            constructor.UseSqlServer(connectionString);
        }
    }
}
