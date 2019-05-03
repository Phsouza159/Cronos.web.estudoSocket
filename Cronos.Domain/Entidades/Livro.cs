using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using prmToolkit.NotificationPattern;
using Cronos.Domain.Entidades.Tipos;

namespace Cronos.Domain.Entidades
{
    [Table("CRONOS_002_LIVRO")]
    public class Livro : EntidadeBase, ILivro
    {
        public Livro()
        {

        }

        public virtual string Titulo { get ; set ; }
        public virtual string Autor { get ; set ; }
        public virtual double? Valor { get ; set ; }
        public virtual int? NumPaginas { get ; set ; }
        public virtual short? Status { get ; set ; }
        public virtual int IdCategoria { get; set; }


        public virtual Livro Valid()
        {
            new AddNotifications<Livro>(this)
                .IfNull(e => e.Titulo);

            return this;
        }

        public virtual List<LivroUsuario> LivroUsuario { get; set; }
        public virtual LivroCategoria LivroCategoria { get; set; }
    }
}
