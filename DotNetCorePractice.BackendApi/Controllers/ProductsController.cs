using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCorePractice.Application.Catalog.Products;
using DotNetCorePractice.ViewModels.Catalog.ProductImages;
using DotNetCorePractice.ViewModels.Catalog.Products;
using DotNetCorePractice.ViewModels.Catalog.Products.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePractice.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _publicProductService.GetAll();
            return Ok(products);
        }

        [HttpGet("get-product-paging")]
        public async Task<IActionResult> Get([FromQuery] GetProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCateogryId(request);
            return Ok(products);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var product = await _manageProductService.GetById(id, languageId);
            if (product == null)
                return BadRequest("Cannot find");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest productCreateRequest)
        {
            var productId = await _manageProductService.Create(productCreateRequest);
            if (productId == 0)
                return BadRequest("Cannot create");

            var product = await _manageProductService.GetById(productId, productCreateRequest.LanguageId);
            return Created(nameof(GetById), product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _manageProductService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(id, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            var result = await _manageProductService.AddImage(productId, request);
            if (result == 0)
                return BadRequest("Cannot create");

            var image = await _manageProductService.GetImageById(result);
            return Created(nameof(GetImageById), image);
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find");
            return Ok(image);
        }

        [HttpPut("/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            var affectedResult = await _manageProductService.UpdateImage(imageId, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int productId, int imageId)
        {
            var affectedResult = await _manageProductService.RemoveImage(productId, imageId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
