using System.Threading.Tasks;
using Store.Core;
using Store.Core.Repositories;
using Store.Data.Repositories;

namespace Store.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private ProductRepository _productRepository;

        public UnitOfWork(StoreContext context)
        {
            this._context = context;
        }
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}