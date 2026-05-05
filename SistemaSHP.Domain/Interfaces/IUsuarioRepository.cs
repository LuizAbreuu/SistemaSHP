using SistemaSHP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSHP.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorEmail(string email);
        Task Adicionar(Usuario usuario);
    }
}
