using ProjWork.Entities;

namespace ProjWork.Repo.Interface
{
    public interface IProductRepo
    {
        //app-> Product Buy and serch items 
        //you are not alllowed to insert any items
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(int skip, int take);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
        public IQueryable<Product> GetProducts();
        int Take { get; }
        int Skip { get; }
     
    }
}
