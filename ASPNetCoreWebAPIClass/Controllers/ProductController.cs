using ASPNetCoreWebAPIClass.Domain.Models.API;
using ASPNetCoreWebAPIClass.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPIClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all-products")]
        public ActionResult<ApiResponse<List<ProductResponse>>> GetAllProducts()
        {

            try
            {
                var productResponses = _productService.GetAllProducts();

                return StatusCode(200, productResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Oops, we are unable to get products");
            }


        }

    }
}
