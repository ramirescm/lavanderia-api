using Lavanderia.Domain.Models;
using System.Threading.Tasks;

namespace Lavanderia.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> BuscarPorLoginSenha(string login, string senha);
    }
}
