using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cronos.Api.Controllers.Base;
using Cronos.Domain.Config;
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
    public class ConfigController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var config = Config.Get().NautilosConif;
            return Ok( config );
        }

    }
}
