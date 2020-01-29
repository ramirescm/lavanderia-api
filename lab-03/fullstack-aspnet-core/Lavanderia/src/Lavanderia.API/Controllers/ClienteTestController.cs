using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lavanderia.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteTestController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteTestController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_clienteRepository.BuscarTodos());
        }


        [HttpPost]
        [Route("lote")]
        public IActionResult InserirLote([FromBody] List<Cliente> clientes)
        {
            try
            {
                _clienteRepository.InserirLote(clientes);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteRepository.AddAsync(cliente);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> Alterar(long id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    throw new Exception("Ocorreu um erro ao atualizaro cliente...");
                }

                cliente = _clienteRepository.Update(cliente);
                return Ok(cliente);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Excluir(long id)
        {
            try
            {
                await _clienteRepository.RemoveAsync(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            try
            {
                var cliente = await _clienteRepository.FindByIdAsync(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}