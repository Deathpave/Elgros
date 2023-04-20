using Elgros.Models;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Elgros.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductManager productmanager)
        {
            _productManager = productmanager;
            _logger = logger;
        }

        [HttpGet("/products")]
        public async Task<IActionResult> Products()
        {
            ProductModel model = new ProductModel(_productManager.GetAllAsync().Result);
            return View("Products", model);
        }
    }
}
