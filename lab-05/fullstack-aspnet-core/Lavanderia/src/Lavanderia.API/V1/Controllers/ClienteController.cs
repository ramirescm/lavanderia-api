using Lavanderia.API.Controllers;
using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.API.V1.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;
        public ClienteController(INotificador notificador,
                                 IClienteService clienteService) : base(notificador)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Cliente cliente, CancellationToken ct = default)
        {
            return CustomResponse(await _clienteService.Adicionar(cliente, ct));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Alterar(long id, [FromBody] Cliente cliente, CancellationToken ct = default)
        {
            return CustomResponse(await _clienteService.Atualizar(cliente, ct));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Excluir(long id, CancellationToken ct = default)
        {
            try
            {
                await _clienteService.Remover(id, ct);
                return NoContent();
            }
            catch (Exception)
            {
                NotificarErro("Erro ao excluir!");
                return CustomResponse();
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id, CancellationToken ct = default)
        {
            return CustomResponse(await _clienteService.BuscarPorId(id, ct));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken ct = default)
        {
            return CustomResponse(await _clienteService.BuscarTodos(ct));
        }
    }
}