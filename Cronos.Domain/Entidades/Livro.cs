using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Entidades
{
    [Table("CRONOS_002_LIVRO")]
    public class Livro : EntidadeBase, ILivro
    {
        public Livro()
        {

        }

        public string Titulo { get ; set ; }
        public string Autor { get ; set ; }
        public double? Valor { get ; set ; }
        public int? NumPaginas { get ; set ; }
        public short? Status { get ; set ; }


        public Livro Valid()
        {
            new AddNotifications<Livro>(this)
                .IfContains(e => e.Titulo , "" , "O campo Titulo não pode ser nulo")
                .IfNull(e => e.Titulo);

            return this;
        }

        public virtual List<LivroUsuario> LivroUsuario { get; set; }
    }
}
