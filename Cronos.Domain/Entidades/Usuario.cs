using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cronos.Domain.Entidades
{
    public class Usuario : EntidadeBase, IUsuario
    {
        public Usuario()
        {

        }

        public Usuario(string nome, string sobrenome, string user, string password, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            User = user;
            Password = password;
            Email = email;
        }

        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string User { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }

        [ForeignKey("Salario")]
        public virtual int? IdSalario { get; set; }

        [ForeignKey("Autentificacao")]
        public virtual int? IdTokien { get; set; }


        public virtual Usuario Valid()
        {
            return this;
        }


        public virtual Salario Salario { get; set; }
        public virtual Autentificacao Autentificacao { get; set; }
        public virtual List<Gasto> Gasto { get; set; }
        public virtual List<LivroUsuario> LivroUsuario { get; set; }
        public virtual ICollection<Mensagem> Mensagens {get;set;}
    }
}
