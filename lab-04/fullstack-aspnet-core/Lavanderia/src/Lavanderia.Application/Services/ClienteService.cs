using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Validations;
using Lavanderia.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IUnitOfWork unitOfWork,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
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
                return cliente;
            }

            await _clienteRepository.AddAsync(cliente, ct);
            await _unitOfWork.CommitAsync(ct);
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente, CancellationToken ct)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return cliente;

            if (_clienteRepository.FindByAsync(f => f.Documento == cliente.Documento && f.Id != cliente.Id, ct).Result.Any())
            {
                Notificar("Já existe um cliente com este documento infomado.");
                return cliente;
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

        public async Task<IEnumerable<Cliente>> BuscarTodos(CancellationToken ct)
        {
            return await _clienteRepository.FindAllAsync(ct);
        }

        public async Task<Cliente> FindSingleOrDefaultAsync(Expression<Func<Cliente, bool>> predicate, CancellationToken ct)
        {
            return await _clienteRepository.FindSingleOrDefaultAsync(predicate, ct);
        }
    }
}
