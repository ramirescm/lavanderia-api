using Lavanderia.API.Controllers;
using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Commons;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Http;
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
            if (id != cliente.Id)
            {
                NotificarErro("Erro ao atualizar!");
                return CustomResponse();
            }
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

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(long id, CancellationToken ct = default)
        {
            var cliente = await _clienteService.BuscarPorId(id, ct);
            return CustomResponse(cliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DefaultParameters">Param</param>
        /// <param name="ct">Token de cancelamento para aborta a requisição caso o usuário clique no x então a requisição é abortada</param>
        /// <response code="200">Hora que exibir a ultima página retornamos ok evitando um novo request ao final que retornaria vazio</response>
        /// <response code="206">Enquanto houver uma próxima página a ser exibida retornamos conteúdo parcial</response>       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status206PartialContent)]
        public async Task<IActionResult> BuscarTodos([FromQuery] DefaultParameters DefaultParameters, CancellationToken ct = default)
        {
            var clientes = await _clienteService.BuscarTodos(DefaultParameters, ct);
            var metadata = new
            {
                clientes.TotalCount,
                clientes.PageSize,
                clientes.CurrentPage,
                clientes.TotalPages,
                clientes.HasNext,
                clientes.HasPrevious
            };

            AddPaginateHeader(metadata);


            return CustomPaginateResponse(clientes);
        }
    }
}