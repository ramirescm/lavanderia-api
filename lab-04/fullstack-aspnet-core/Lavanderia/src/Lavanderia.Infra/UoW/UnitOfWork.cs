using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Infra.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
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
    }
}
