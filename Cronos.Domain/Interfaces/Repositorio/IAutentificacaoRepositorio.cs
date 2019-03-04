using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IAutentificacaoRepositorio :  IRepositorioBase<Autentificacao , int> 
    {
        Usuario GetTokien(string Tokien);
        bool ValidarTokien(string Tokien);
    }
}
