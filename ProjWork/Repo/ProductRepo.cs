using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities;
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
        public int Take { get; private set; }

        public int Skip { get; private set; }


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
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(int skip, int take)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Skip(skip)
                .Take(take)
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