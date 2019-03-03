using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [DisableCors]
    public class UserController : ControllerBase
    {
        IMapeamento _Mapper { get; set; }
        IUsuarioServico UsuarioServico { get; set; }
        IRepositorioCommit DbService { get; set; }

        public UserController(IMapeamento mapeamento , IUsuarioServico usuarioServico , IRepositorioCommit DbService)
        {
            _Mapper = mapeamento;
            UsuarioServico = usuarioServico;
            this.DbService = DbService;
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

        [HttpPost("{obj}")]
        public IActionResult Login([FromBody] LoginRequest data)
        {
            return Ok(data);
        }

        [HttpPost("{data}" , Name = "New")]
        public IActionResult New([FromBody] UserRequest data)
        {
            Usuario user = _Mapper.MapUsuario(data);

            UsuarioServico.AddUser(user);
            DbService.Commit();

            return Ok();
        }

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
