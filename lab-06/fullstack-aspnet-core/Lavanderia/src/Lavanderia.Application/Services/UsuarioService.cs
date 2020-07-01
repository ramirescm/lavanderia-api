using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Notificacoes;
using System.Threading.Tasks;

namespace Lavanderia.Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> BuscarPorLoginSenha(string login, string senha)
        {
            return await _usuarioRepository.BuscarPorLoginSenha(login, senha);
        }
    }
}
