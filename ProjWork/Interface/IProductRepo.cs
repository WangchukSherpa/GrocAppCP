using ProjWork.Model;

namespace ProjWork.Interface
{
    public interface IProductRepo
    {
        //app-> Product Buy and serch items 
        //you are not alllowed to insert any items
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
        public IQueryable<Product> GetProducts();
    }
}
