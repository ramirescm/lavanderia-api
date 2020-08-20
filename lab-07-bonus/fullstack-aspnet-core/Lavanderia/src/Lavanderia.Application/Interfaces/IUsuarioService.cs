using Lavanderia.Domain.Models;
using System.Threading.Tasks;

namespace Lavanderia.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> BuscarPorLoginSenha(string login, string senha);
    }
}
