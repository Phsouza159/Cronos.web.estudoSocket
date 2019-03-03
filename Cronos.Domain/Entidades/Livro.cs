using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool? Lido { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }

        public Livro Valid()
        {
            return this;
        }

        public virtual List<LivroUsuario> LivroUsuario { get; set; }
    }
}
