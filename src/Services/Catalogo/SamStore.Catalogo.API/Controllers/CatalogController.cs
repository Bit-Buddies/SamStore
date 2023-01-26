using Microsoft.AspNetCore.Mvc;
using SamStore.Catalogo.API.Domain.Interfaces;
using SamStore.Catalogo.API.Domain.Products;
using SamStore.Core.API.Controllers;

namespace SamStore.Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : MainController
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();

            return CustomResponse(products);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product product = await _productRepository.GetById(id);

            return CustomResponse(product);
        }
    }
}
