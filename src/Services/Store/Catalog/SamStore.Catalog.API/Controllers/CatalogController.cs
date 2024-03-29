﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.Catalog.API.Domain.Interfaces;
using SamStore.Catalog.API.Domain.Products;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.Identity.Claims;
using System.Net;

namespace SamStore.Catalog.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class CatalogController : CustomController
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products for Catalog
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();

            return CustomResponse(products);
        }


        /// <summary>
        /// Get a specific product passing id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("products/{id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            return CustomResponse(product);
        }
    }
}
