using BancoDigital.Domain.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Repository.Interfaces
{
    public interface IUsuarioPFInterface
    {
        Task<UsuarioPF> BuscarUsuario(string cpf);
        Task<List<UsuarioPF>> BuscarTodosUsuarios();
        Task<UsuarioPF> AddUsuario(UsuarioPF usuario);
        Task<UsuarioPF> AtualizarUsuario(UsuarioPF usuario,string cpf);
        Task<bool> RemoverPessoaFisica (string cpf);
        bool VerificarMaiorIdade(UsuarioPF usuario);
        bool VerificarCadastroPF(string cpf);
        bool ValidarCpf(string cpf);


    }
}
