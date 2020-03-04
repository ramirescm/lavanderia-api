using Lavanderia.API.Controllers;
using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;
        public ClienteController(INotificador notificador,
                                 IClienteService clienteService) : base(notificador)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken ct = default)
        {
            return CustomResponse(await _clienteService.BuscarTodos(ct));
        }
    }
}