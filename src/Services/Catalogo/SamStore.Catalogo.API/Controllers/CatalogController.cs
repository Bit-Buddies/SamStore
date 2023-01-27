using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.Catalogo.API.Domain.Interfaces;
using SamStore.Catalogo.API.Domain.Products;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.Identity.Claims;

namespace SamStore.Catalogo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/catalog")]
    public class CatalogController : MainController
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();

            return CustomResponse(products);
        }

        [ClaimsAuthorize("Catalog", "Read")]
        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product product = await _productRepository.GetById(id);

            return CustomResponse(product);
        }
    }
}
