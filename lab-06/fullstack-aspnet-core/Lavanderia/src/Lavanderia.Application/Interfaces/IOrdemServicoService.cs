using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Commons;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<OrdemServico> Adicionar(OrdemServico ordemServico, CancellationToken ct);
        Task<OrdemServico> Atualizar(OrdemServico ordemServico, CancellationToken ct);
        Task Remover(long id, CancellationToken ct);
        Task<OrdemServico> BuscarPorId(long id, CancellationToken ct);
        Task<PagedList<OrdemServico>> BuscarTodos(DefaultParameters ownerParameters, CancellationToken ct);
        Task<OrdemServico> FindSingleOrDefaultAsync(Expression<Func<OrdemServico, bool>> predicate, CancellationToken ct);
    }
}
