using Lavanderia.Domain.Models;
using System;
using System.Collections.Generic;
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
        Task<IEnumerable<OrdemServico>> BuscarTodos(CancellationToken ct);
        Task<OrdemServico> FindSingleOrDefaultAsync(Expression<Func<OrdemServico, bool>> predicate, CancellationToken ct);
    }
}
