using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManagementSystem.Model.CommandModel;
using ProductInventoryManagementSystem.Service.Interfaces;

namespace ProductInventoryManagementSystem.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// For adding product
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(ProductCommandModel productCommandModel)
        {
            try
            {
                var result = await _productService.AddProduct(productCommandModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
