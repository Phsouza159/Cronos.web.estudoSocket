﻿using Cronos.Api.Controllers.Base;
using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using Cronos.Domain.Response;
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
    
        [HttpGet("{Tokien}", Name = "Get")]
        public IActionResult Get(string Tokien)
        {
            string NewTokien = this.ValidarAcesso(Tokien);
            if (NewTokien != null)
            {
                LivroResponse response = new LivroResponse()
                {
                    Tokien = NewTokien,
                    Livros = LivroServico.GetByLivroUsuario(this.UserLogado.Id)
                };
                if(this.Commit())
                    return Ok(response);
            }
            return NotFound();
        }

        [HttpPost("{obj}", Name = "Adicionar")]
        public IActionResult Adicionar([FromBody] LivroRequest request)
        {
            string NewTokien = this.ValidarAcesso(request.Tokien);

            if (NewTokien != null )
            {
                Livro livro = _Mapeamento.MapLivro(request);

                LivroServico.Add(livro.Valid());
                LivroServico.Vincular(livro.Id , this.UserLogado.Id);

                return Ok(this.Commit(request, NewTokien, livro));
            }
            return NotFound();
        }

        [HttpPut("{obj}", Name = "Editar")]
        public IActionResult Editar([FromBody] LivroRequest request)
        {
            string NewTokien = this.ValidarAcesso(request.Tokien);

            if (NewTokien != null)
            {
                Livro Livro = _Mapeamento.MapLivro(request);
                Livro LivroAtualizado = LivroServico.Edit(Livro);

                return Ok(this.Commit(LivroAtualizado, NewTokien , LivroServico));
            }
            return NotFound();
        }
    }
}
