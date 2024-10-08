using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjWork;
using ProjWork.Entities;
using ProjWork.Helper;
using ProjWork.Repo.Interface;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _pRepo;
        private readonly ProductFilterHelper _productfilter;

        public ProductsController(IProductRepo repo,ProductFilterHelper productFilter)
        {
            _pRepo = repo;
            _productfilter = productFilter;
        }

        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
            string? sortBy=null, 
            int? productTypeId=null,
            int? productBrandId=null,
            int skip=0,
            int take=10
            )
        {
            var products = _pRepo.GetProducts();
            products = _productfilter.ApplySort(products,
            sortBy, productTypeId, productBrandId);
            var paginatedProducts = await products.Skip(skip).Take(take).ToListAsync();
            return Ok(paginatedProducts);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _pRepo.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
        {
            var brands = await _pRepo.GetProductBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            var types = await _pRepo.GetProductTypeAsync();
            return Ok(types);
        }
    }
}
