using Cronos.Api.Controllers.Base;
using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using Cronos.Domain.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ApiBase
    {
        ILivroServico LivroServico { get; set; }
        IMapeamento _Mapeamento { get; set; }

        public LivroController(IRepositorioCommit DbService, IAutentificacaoServico AutentificacaoServico , ILivroServico LivroServico , IMapeamento _Mapeamento) 
            : base(DbService, AutentificacaoServico)
        {
            this.LivroServico = LivroServico;
            this._Mapeamento = _Mapeamento;
        }

        [HttpPost("{obj}", Name = "Adicionar")]
        public IActionResult Adicionar([FromBody] LivroRequest request)
        {
            Livro livro = _Mapeamento.MapLivro(request);

            LivroServico.Add(livro.Valid());

            return Ok(this.Commit( request, livro));

        }

    }
}
