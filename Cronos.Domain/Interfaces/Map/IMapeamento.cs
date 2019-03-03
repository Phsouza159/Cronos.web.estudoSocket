using Cronos.Domain.Entidades;
using Cronos.Domain.Request;

namespace Cronos.Domain.Interfaces.Map
{
    public interface IMapeamento
    {
        /// <summary>
        /// Mapear UserRequest para Usuario
        /// </summary>
        Usuario MapUsuario(UserRequest request);

        /// <summary>
        /// Mapear UserRequest para Salario 
        /// </summary>
        Salario MapSalario(UserRequest request);
    }
}
