using Elgros.Models;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Elgros.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("/products")]
        public async Task<IActionResult> Products()
        {
            ProductModel model = new ProductModel(_productManager.GetAllAsync().Result);
            return View("Products", model);
        }
    }
}
