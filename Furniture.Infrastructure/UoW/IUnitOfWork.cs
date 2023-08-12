using Furniture.Data.Entities;
using PCMS.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace PCMS.Infrastructure.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; set; }


        Task Commit();
    }
}
