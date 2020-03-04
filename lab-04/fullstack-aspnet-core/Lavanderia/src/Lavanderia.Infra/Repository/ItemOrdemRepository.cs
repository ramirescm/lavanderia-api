using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Infra.Repository
{
    public class ItemOrdemRepository : Repository<ItensOrdens>, IItemOrdemRepository
    {
        public ItemOrdemRepository(LavanderiaContext context) : base(context)
        {
        }

        public async Task AddItens(List<ItensOrdens> itens, CancellationToken ct = default)
        {
            foreach (var item in itens)
            {
                var itemOrdem = await FindByIdAsync(new object[] { item.ItemId, item.OrdemId });
                if (itemOrdem == null)
                {
                    await AddAsync(item);
                }
            }
        }
    }
}
