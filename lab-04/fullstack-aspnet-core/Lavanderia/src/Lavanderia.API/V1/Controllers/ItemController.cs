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
    [Route("api/itens")]
    [ApiController]
    public class ItemController : MainController
    {
        private readonly IItemService _itemService;

        public ItemController(INotificador notificador,
                              IItemService itemService) : base(notificador)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Item item, CancellationToken ct = default)
        {
            return CustomResponse(await _itemService.Adicionar(item, ct));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Alterar(long id, [FromBody] Item item, CancellationToken ct = default)
        {
            return CustomResponse(await _itemService.Atualizar(item, ct));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Excluir(long id, CancellationToken ct = default)
        {
            try
            {
                await _itemService.Remover(id, ct);
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
            return CustomResponse(await _itemService.BuscarPorId(id, ct));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken ct = default)
        {
            return CustomResponse(await _itemService.BuscarTodos(ct));
        }
    }
}