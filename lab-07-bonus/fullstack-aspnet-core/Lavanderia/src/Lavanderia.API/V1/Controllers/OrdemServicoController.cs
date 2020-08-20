using Lavanderia.API.Controllers;
using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Commons;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.API.V1.Controllers
{
    [Route("api/ordensservico")]
    [ApiController]
    public class OrdemServicoController : MainController
    {
        public readonly IOrdemServicoService _ordemServicoService;
        public OrdemServicoController(INotificador notificador,
                                      IOrdemServicoService ordemServicoService) : base(notificador)
        {
            _ordemServicoService = ordemServicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] OrdemServico ordemServico, CancellationToken ct = default)
        {
            return CustomResponse(await _ordemServicoService.Adicionar(ordemServico, ct));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Alterar(long id, [FromBody] OrdemServico ordemServico, CancellationToken ct = default)
        {
            return CustomResponse(await _ordemServicoService.Atualizar(ordemServico, ct));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Excluir(long id, CancellationToken ct = default)
        {
            try
            {
                await _ordemServicoService.Remover(id, ct);
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
            return CustomResponse(await _ordemServicoService.BuscarPorId(id, ct));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos([FromQuery] DefaultParameters defaultParameters, CancellationToken ct = default)
        {
            return CustomResponse(await _ordemServicoService.BuscarTodos(defaultParameters, ct));
        }
    }
}