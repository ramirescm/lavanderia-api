using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Services
{
    public class OrdemServicoService : BaseService, IOrdemServicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IItemOrdemRepository _itemOrdemRepository;

        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository,
                                   IItemOrdemRepository itemOrdemRepository,
                                   IUnitOfWork unitOfWork,
                                   INotificador notificador) : base(notificador)
        {
            _ordemServicoRepository = ordemServicoRepository;
            _itemOrdemRepository = itemOrdemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrdemServico> Adicionar(OrdemServico ordemServico, CancellationToken ct)
        {
            await _ordemServicoRepository.AddAsync(ordemServico, ct);
            await _itemOrdemRepository.AddItens(ordemServico.Items, ct);
            await _unitOfWork.CommitAsync(ct);
            return ordemServico;
        }

        public async Task<OrdemServico> Atualizar(OrdemServico ordemServico, CancellationToken ct)
        {
            _ordemServicoRepository.Update(ordemServico);
            await _itemOrdemRepository.AddItens(ordemServico.Items, ct);
            await _unitOfWork.CommitAsync(ct);
            return ordemServico;
        }

        public async Task Remover(long id, CancellationToken ct)
        {
            await _ordemServicoRepository.RemoveAsync(id, ct);
            await _unitOfWork.CommitAsync(ct);
        }

        public async Task<OrdemServico> BuscarPorId(long id, CancellationToken ct)
        {
            return await _ordemServicoRepository.FindByIdAsync(id, ct);
        }

        public async Task<IEnumerable<OrdemServico>> BuscarTodos(CancellationToken ct)
        {
            return await _ordemServicoRepository.FindAllAsync(ct);
        }

        public async Task<OrdemServico> FindSingleOrDefaultAsync(Expression<Func<OrdemServico, bool>> predicate, CancellationToken ct)
        {
            return await _ordemServicoRepository.FindSingleOrDefaultAsync(predicate, ct);
        }
    }
}
