using Lavanderia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Interfaces
{
    public interface IItemService
    {
        Task<Item> Adicionar(Item item, CancellationToken ct);
        Task<Item> Atualizar(Item item, CancellationToken ct);
        Task Remover(long id, CancellationToken ct);
        Task<Item> BuscarPorId(long id, CancellationToken ct);
        Task<IEnumerable<Item>> BuscarTodos(CancellationToken ct);
        Task<Item> FindSingleOrDefaultAsync(Expression<Func<Item, bool>> predicate, CancellationToken ct);
    }
}
