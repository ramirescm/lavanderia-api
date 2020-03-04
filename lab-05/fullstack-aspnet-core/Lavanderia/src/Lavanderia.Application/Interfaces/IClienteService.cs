using Lavanderia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Adicionar(Cliente cliente, CancellationToken ct);
        Task<Cliente> Atualizar(Cliente cliente, CancellationToken ct);
        Task Remover(long id, CancellationToken ct);
        Task<Cliente> BuscarPorId(long id, CancellationToken ct);
        Task<IEnumerable<Cliente>> BuscarTodos(CancellationToken ct);
        Task<Cliente> FindSingleOrDefaultAsync(Expression<Func<Cliente, bool>> predicate, CancellationToken ct);
        //Task<Cliente> FindByEmailSenha(string email, string senha, CancellationToken ct);
    }
}
