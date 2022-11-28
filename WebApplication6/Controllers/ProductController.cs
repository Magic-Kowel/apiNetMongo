using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.Repositories;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
       private IProductCollection db = new ProductCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            if (product.Name == string.Empty) {
                ModelState.TryAddModelError("Name","The product shouldn't be empty");
            }
            await db.InsertProduct(product);
            return Created("created",true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product,string id)
        {
            if (product == null)
                return BadRequest();
            if (product.Name == string.Empty)
            {
                ModelState.TryAddModelError("Name", "The product shouldn't be empty");
            }
            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);
            return Created("created", true);
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteProduct(string id)
        {
            await db.DeleteProduct(id);
            return NoContent();
        }
    }
}
