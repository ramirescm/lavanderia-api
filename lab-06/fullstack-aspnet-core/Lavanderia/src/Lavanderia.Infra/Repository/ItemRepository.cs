using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;

namespace Lavanderia.Infra.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(LavanderiaContext context) : base(context)
        {
        }
    }
}
