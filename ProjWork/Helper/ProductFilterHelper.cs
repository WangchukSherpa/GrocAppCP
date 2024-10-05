using ProjWork.Model;

namespace ProjWork.Helper
{
    public class ProductFilterHelper
    {
        public IQueryable<Product> ApplySort(
            IQueryable<Product> products,
            string? sortBy,
            int? productTypeId,
            int? productBrandId 
            ) {
           
            
            //Filter using product Brand
            if (productBrandId.HasValue)
               products = products.Where(p => p.ProductBrandId == productBrandId.Value);
            //Filter using product Type
            if (productTypeId.HasValue)
                products = products.Where(p => p.ProductTypeId == productTypeId.Value);
            //Filter using the price and alphabet order
            if (string.IsNullOrEmpty(sortBy)) return products;
            switch (sortBy.ToLower()) {
                case "priceasc":
                    products=products.OrderBy(x => x.Price);
                    break;
                case "pricedesc":
                    products=products.OrderByDescending(x => x.Price);
                    break;
                case "name":
                    products= products.OrderBy(x => x.Name);
                    break;
                case "namedesc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                default:
                    break;
            }
            return products;
        } 
        
     }
}
