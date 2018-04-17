using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Models;
//using ProductManagement.Data;

namespace EshopApi.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/pm")]
    public class ProductManagementController : Controller
    {
        private readonly IProductManagmentRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProductManagementController
            (IMapper _mapper,
            IProductManagmentRepository repository,
            IUnitOfWork unitOfWork)
        {
            //DbContext = dbContext;
            mapper = _mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IMapper mapper { get; }

        [Route("vendors")]
        public async Task<IEnumerable<VendorResource>> GetVendors()
        {
            var vendors = await repository.GetVendorsAsync();
            var result = mapper.Map<IEnumerable<Vendor>, IEnumerable<VendorResource>>(vendors);
            return result;
        }
        [HttpGet("categories")]
        public async Task<IEnumerable<CategoryResource>> GetCategories()
        {
           this.HttpContext.Response.Headers.Add
                ("Access-Control-Allow-Origin", " *");
            var categories = await repository.GetCategoriesAsync();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
        }
        [HttpGet("products")]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        {
            
            var products = await repository.GetAllProductsAsync();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }
        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct
            ([FromBody]InputProductResource product)
        {
            var newProduct = mapper.Map<InputProductResource, Product>(product);

            await repository.AddProductAsync(newProduct);

            await unitOfWork.CompleteAsync();

            var prodToReturn = mapper.Map<Product, ProductResource>(newProduct);

            return Ok(prodToReturn);
        }
        [HttpPut("products/{id}")] // api/pm/products/1  
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]InputProductResource inputProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Solve heavey queries using either repository ot command\query pattern
            //var product = await DbContext.Products
            //    .Include(p => p.Features)
            //    .ThenInclude(pf => pf.Feature)
            //    .Include(p => p.Category)
            //    .Include(p => p.Vendor)
            //    .SingleOrDefaultAsync(p => p.Id == id);

            var product = await repository.GetProductAsync(id);

            if (product == null)
                return NotFound();

            product.LastChanged = DateTime.Now;

            Mapper.Map<InputProductResource, Product>(inputProduct, product);

            //await DbContext.SaveChangesAsync();
            await unitOfWork.CompleteAsync();
            var result = Mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            var currentProduct = await repository.GetProductAsync(id, includeRelated: false);
            if (currentProduct == null)
                return NotFound();

            repository.RemoveProduct(currentProduct);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult>GetProduct(int id)
        {
            var currentProduct = 
                await repository.GetProductAsync(id);

            if (currentProduct == null)
                return NotFound();

            var result = Mapper.Map<Product, ProductResource>(currentProduct);
            return Ok(result);
        }
    }
}