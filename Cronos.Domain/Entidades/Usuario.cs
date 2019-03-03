using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cronos.Domain.Entidades
{
    public class Usuario : EntidadeBase , IUsuario
    {
        public Usuario()
        {

        }

        public Usuario(string nome, string sobrenome, string user, string password, string email, int? idSalario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            User = user;
            Password = password;
            Email = email;
            IdSalario = idSalario;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [ForeignKey("Salario")]
        public int? IdSalario { get; set; }

        
        public Usuario Valid()
        {
            return this;
        }

         
        public virtual Salario Salario { get; set; }
        public virtual List<Gasto> Gasto { get; set; }
        public virtual List<LivroUsuario> LivroUsuario { get; set; }
       
    }
}
