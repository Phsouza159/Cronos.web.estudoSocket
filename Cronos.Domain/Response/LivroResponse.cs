using Cronos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Response
{
    public class LivroResponse
    {
        public string Tokien { get; set; }
        public List<ListLivroResponse> Livros { get; set; }
    }

    public class ListLivroResponse
    {
        public string Id { get; set; }
        public int? IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public double? Valor { get; set; }
        public int? NumPaginas { get; set; }
        public short? Status { get; set; }
    }
}
