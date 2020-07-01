using Lavanderia.Application.Interfaces;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Models.Commons;
using Lavanderia.Domain.Notificacoes;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Application.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository,
                           IUnitOfWork unitOfWork,
                           INotificador notificador) : base(notificador)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Item> Adicionar(Item item, CancellationToken ct)
        {
            await _itemRepository.AddAsync(item, ct);
            await _unitOfWork.CommitAsync(ct);
            return item;
        }

        public async Task<Item> Atualizar(Item item, CancellationToken ct)
        {
            _itemRepository.Update(item);
            await _unitOfWork.CommitAsync(ct);
            return item;
        }

        public async Task Remover(long id, CancellationToken ct)
        {
            await _itemRepository.RemoveAsync(id, ct);
            await _unitOfWork.CommitAsync(ct);
        }

        public async Task<Item> BuscarPorId(long id, CancellationToken ct)
        {
            return await _itemRepository.FindByIdAsync(id, ct);
        }

        public async Task<PagedList<Item>> BuscarTodos(DefaultParameters ownerParameters, CancellationToken ct)
        {
            return await _itemRepository.FindAllAsync(ownerParameters, ct);
        }

        public async Task<Item> FindSingleOrDefaultAsync(Expression<Func<Item, bool>> predicate, CancellationToken ct)
        {
            return await _itemRepository.FindSingleOrDefaultAsync(predicate, ct);
        }
    }
}
