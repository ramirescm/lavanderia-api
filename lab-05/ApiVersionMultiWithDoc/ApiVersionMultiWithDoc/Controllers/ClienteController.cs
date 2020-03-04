using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiVersionMultiWithDoc.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("/versao-nova")]
        public IEnumerable<Cliente> GetAll()
        {
            return new List<Cliente>
               {
                   new Cliente { Nome = "João" },
                   new Cliente { Nome = "Maria" }
               };
        }

        [HttpGet("/versao-antiga")]
        [Obsolete("Usar a versão mais recente essa vai ser desabilitada dia 12/10/2020")]
        public IEnumerable<Cliente> GetAll1()
        {
            return new List<Cliente>
               {
                   new Cliente { Nome = "João" },
                   new Cliente { Nome = "Maria" }
               };
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }
    }
}