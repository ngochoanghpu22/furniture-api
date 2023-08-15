using Furniture.Data.Entities;
using PCMS.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace PCMS.Infrastructure.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; set; }

        IRepository<Category, int> CategoryRepository { get; set; }

        IRepository<Product, int> ProductRepository { get; set; }

        IRepository<Order, int> OrderRepository { get; set; }

        IRepository<OrderDetail, int> OrderDetailRepository { get; set; }


        Task Commit();
    }
}
