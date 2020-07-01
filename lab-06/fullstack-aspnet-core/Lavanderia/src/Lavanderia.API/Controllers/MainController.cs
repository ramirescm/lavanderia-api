using Lavanderia.Domain.Models.Commons;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Text.Json;

namespace Lavanderia.API.Controllers
{
    [Authorize]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponseNotFound(object result = null)
        {
            return NotFound(new
            {
                success = false,
                data = result
            });
        }


        // DESAFIO usar uma classe wrapper para padronizar a saida
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
                // Dependendo da forma como precisar ser tratada no front
                //errors = _notificador.ObterNotificacoes().ToDictionary(n => n.Campo, n => n.Mensagem)
            });
        }

        protected ActionResult CustomPaginateResponse<T>(PagedList<T> result = null)
        {
            if (OperacaoValida() && result.HasNext)
            {
                // DESAFIO pesquisar a classe no ASPNET CORE que contenha o status code
                return StatusCode(206, new
                {
                    success = true,
                    data = result
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected void AddPaginateHeader(object obj)
        {
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(obj));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
