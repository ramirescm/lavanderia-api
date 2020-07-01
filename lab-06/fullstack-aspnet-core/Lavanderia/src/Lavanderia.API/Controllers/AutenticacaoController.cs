using Lavanderia.Application.Interfaces;
using Lavanderia.Application.Services;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lavanderia.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AutenticacaoController : MainController
    {
        public readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService,
                                      INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            // Recuperamos o usuário do banco
            var usuario = await _usuarioService.BuscarPorLoginSenha(model.Login, model.Senha);

            // Verificamos se o usuário existe
            if (usuario == null)
            {
                //NotificarErro("Usuário ou senha inválidos");
                return CustomResponseNotFound("Usuário ou senha inválidos");
            }

            // Geramos o Token com as informações do usuário
            var token = TokenService.GenerateToken(usuario);

            // Ocultamos a senha
            usuario.Senha = "";

            // Retorna os dados
            return CustomResponse(new { usuario, token });
        }
    }
}