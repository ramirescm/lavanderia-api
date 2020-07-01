using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Commons;
using Lavanderia.Domain.Models.Validations;
using Lavanderia.Domain.Notificacoes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IUnitOfWork unitOfWork,
                              INotificador notificador,
                              IServiceScopeFactory scopeFactory) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            _scopeFactory = scopeFactory;
        }

        public async Task<Cliente> Adicionar(Cliente cliente, CancellationToken ct)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente))
            {
                return cliente;
            }

            if (_clienteRepository.FindByAsync(f => f.Documento == cliente.Documento, ct).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return null;
            }

            // https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
            // Using dependency injection, this can be achieved by either registering the context as scoped, and creating scopes(using IServiceScopeFactory) for each thread, or by registering the DbContext as transient (using the overload of AddDbContext which takes a ServiceLifetime parameter).

            // https://blog.hildenco.com/2018/12/accessing-entity-framework-context-on.html
            // 1 - forma de trabalhar com concorrencia
            //using (var scopoe = _scopeFactory.CreateScope())
            //{
            //    var db = scopoe.ServiceProvider.GetRequiredService<LavanderiaContext>();
            //    await db.Clientes.AddAsync(cliente, ct);
            //    await db.SaveChangesAsync();
            //}

            await _clienteRepository.AddAsync(cliente, ct);
            await _unitOfWork.CommitAsync(ct);
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente, CancellationToken ct)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return cliente;

            if (_clienteRepository.FindByAsync(f => f.Documento == cliente.Documento && f.Id != cliente.Id, ct).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return null;
            }

            _clienteRepository.Update(cliente);
            await _unitOfWork.CommitAsync(ct);
            return cliente;
        }

        public async Task Remover(long id, CancellationToken ct)
        {
            await _clienteRepository.RemoveAsync(id, ct);
            await _unitOfWork.CommitAsync(ct);
        }

        public async Task<Cliente> BuscarPorId(long id, CancellationToken ct)
        {
            return await _clienteRepository.FindByIdAsync(id, ct);
        }

        public async Task<PagedList<Cliente>> BuscarTodos(DefaultParameters ownerParameters, CancellationToken ct)
        {
            return await _clienteRepository.FindAllAsync(ownerParameters, ct);
        }

        public async Task<Cliente> FindSingleOrDefaultAsync(Expression<Func<Cliente, bool>> predicate, CancellationToken ct)
        {
            return await _clienteRepository.FindSingleOrDefaultAsync(predicate, ct);
        }
    }
}
