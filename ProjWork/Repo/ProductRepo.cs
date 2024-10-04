using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Model;
using ProjWork.Repo.Interface;

namespace ProjWork.Repo
{
    //dbContext => Repo
    //IProdRepo => Controller
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext _context;
        public ProductRepo(ProductDbContext context)
        {
            _context = context;
        }
        //thread basic unit of utilize cpu
        //Task a single unit of work
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
        }
        public IQueryable<Product> GetProducts()
        {
            return _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .AsQueryable(); 
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
