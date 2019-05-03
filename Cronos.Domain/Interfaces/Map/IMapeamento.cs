using Cronos.Domain.Config;
using Cronos.Domain.Entidades;
using Cronos.Domain.Request;
using Cronos.Domain.Response;

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

        /// <summary>
        /// Mapear LivroRequest para Livro
        /// </summary>
        Livro MapLivro(LivroRequest request);
        ListLivroResponse MapLivro(Livro livro);

        /// <summary>
        /// usuario para UserResponse
        /// </summary>
        UserResponse MapUserResponse(Usuario request);

        NautilosConig MapNautilosConfig(dynamic request);
    }
}
