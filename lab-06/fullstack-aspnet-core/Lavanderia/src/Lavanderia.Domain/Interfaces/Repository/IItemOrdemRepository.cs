using Lavanderia.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Domain.Interfaces.Repository
{
    public interface IItemOrdemRepository : IRepository<ItensOrdens>
    {
        public Task AddItens(List<ItensOrdens> itens, CancellationToken ct = default);
    }
}
