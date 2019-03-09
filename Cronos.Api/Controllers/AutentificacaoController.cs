using Cronos.Api.Controllers.Base;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutentificacaoController : ApiBase
    {
        public AutentificacaoController(IRepositorioCommit DbService, IAutentificacaoServico AutentificacaoServico) 
            : base(DbService, AutentificacaoServico)
        {
        }

        [HttpGet]
        public bool LogOff(string tokien)
        {
          return this.EfetuarLogoff(tokien);
        }

        [HttpPost("{data}")]
        public IActionResult Login([FromBody] LoginRequest data)
        {
            return Ok(this.ValidarAcesso(data.Usuario, data.Senha));
        }
    }
}
