using System;
using System.Threading.Tasks;
using Store.Core.Repositories;

namespace Store.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}