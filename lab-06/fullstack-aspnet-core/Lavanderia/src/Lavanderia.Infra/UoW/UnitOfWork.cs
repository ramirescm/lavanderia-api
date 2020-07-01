using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Infra.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        // TODO: Desafio implementar UOW com repositórios


        public readonly LavanderiaContext _context;
        public UnitOfWork(LavanderiaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct) > 0;
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void DisposeTransaction()
        {
            _context.Database.CurrentTransaction.Dispose();
        }
    }
}
