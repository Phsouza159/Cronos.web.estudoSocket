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

        public UserController(IMapeamento mapeamento , IUsuarioServico usuarioServico , IRepositorioCommit DbService , IAutentificacaoServico AutentificacaoServico)
            :base(DbService , AutentificacaoServico)
        {
            _Mapper = mapeamento;
            UsuarioServico = usuarioServico;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("{obj}" , Name = "Login")]
        public IActionResult Login([FromBody] LoginRequest data)
        {
            return Ok(this.ValidarAcesso(data.Usuario, data.Senha));
        }

        //[HttpPost("{data}" , Name = "New")]
        //public IActionResult New([FromBody] UserRequest data)
        //{
        //    Usuario user = _Mapper.MapUsuario(data);
        //    UsuarioServico.AddUser(user);

        //    return Ok();
        //}

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
