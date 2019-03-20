using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cronos.Api.Controllers.Base;
using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cronos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBase
    {
        IMapeamento _Mapper { get; set; }
        IUsuarioServico UsuarioServico { get; set; }

        public UserController(IMapeamento mapeamento, IUsuarioServico usuarioServico, IRepositorioCommit DbService, IAutentificacaoServico AutentificacaoServico)
            : base(DbService, AutentificacaoServico)
        {
            _Mapper = mapeamento;
            UsuarioServico = usuarioServico;
        }

        [HttpPost("{data}")]
        public IActionResult Novo([FromBody] UserRequest data)
        {
            string tokien = "";

            Usuario user = _Mapper.MapUsuario(data);
            UsuarioServico.AddUser(user);

            var obj = this.Commit(new object(), tokien , UsuarioServico);
            var resp = this.ValidarAcesso(data.NomeUser, data.Senha);

            obj = this.Commit(new object(), tokien , UsuarioServico);
            resp.Tokien = tokien;

            return Ok(resp);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
