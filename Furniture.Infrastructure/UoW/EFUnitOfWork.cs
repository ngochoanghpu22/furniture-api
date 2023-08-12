using System.Threading.Tasks;
using Furniture.Data;
using Furniture.Data.Entities;
using PCMS.Infrastructure.Repositories;

namespace PCMS.Infrastructure.UoW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly FurnitureContext _context;

        public IRepository<User, int> UserRepository { get; set; }

        public EFUnitOfWork(FurnitureContext context,
            IRepository<User, int> userRepository
        )

        {
            _context = context;
            UserRepository = userRepository;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}