using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;
using System.Threading.Tasks;

namespace Lavanderia.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LavanderiaContext context) : base(context)
        {
        }

        public async Task<Usuario> BuscarPorLoginSenha(string login, string senha)
        {
            return await FindSingleOrDefaultAsync(e => e.Login == login && e.Senha == senha);
        }
    }
}
