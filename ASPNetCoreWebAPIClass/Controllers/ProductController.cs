using ASPNetCoreWebAPIClass.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPIClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        [Route("get-all-products")]
        public IActionResult GetAllProducts()
        {
            List<ProdutResponse> products = new List<ProdutResponse>
            {
                new ProdutResponse { Id = 1, Name = "Jacket", Price = 20000M, Quantity = 5 },
                new ProdutResponse { Id = 2, Name = "Wristwatch", Price = 25000M, Quantity = 5 },
                new ProdutResponse { Id = 3, Name = "Phone", Price = 70000M, Quantity = 5 },
                new ProdutResponse { Id = 4, Name = "TV", Price = 2600M, Quantity = 5 },
                new ProdutResponse { Id = 5, Name = "Laptop", Price = 90000M, Quantity = 5 }
            };


            return Ok(products);

        }

    }
}
