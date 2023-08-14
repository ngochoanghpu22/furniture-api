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

        public IRepository<Category, int> CategoryRepository { get; set; }

        public IRepository<Product, int> ProductRepository { get; set; }

        public IRepository<Order, int> OrderRepository { get; set; }

        public EFUnitOfWork(FurnitureContext context,
            IRepository<User, int> userRepository,
            IRepository<Category, int> categoryRepository,
            IRepository<Product, int> productRepository,
            IRepository<Order, int> orderRepository
        )

        {
            _context = context;
            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
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