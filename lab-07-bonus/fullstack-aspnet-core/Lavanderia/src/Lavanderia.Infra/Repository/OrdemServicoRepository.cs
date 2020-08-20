using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;

namespace Lavanderia.Infra.Repository
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(LavanderiaContext context) : base(context)
        {
        }
    }
}
