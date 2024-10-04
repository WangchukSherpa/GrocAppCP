using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjWork;
using ProjWork.Helper;
using ProjWork.Model;
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
        public  ActionResult<IReadOnlyList<Product>> GetProducts(
            string? sortBy=null, 
            int? productTypeId=null,
            int? productBrandId=null
            )
        {
            var products = _pRepo.GetProducts();// Await the task to get the result
            products = _productfilter.ApplySort(products,
            sortBy, productTypeId, productBrandId);
            return Ok(products);
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
