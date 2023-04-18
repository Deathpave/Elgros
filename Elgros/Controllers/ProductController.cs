using Elgros.Models;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Elgros.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        [HttpPost("/products")]
        public async Task<ActionResult> products()
        {
            ProductModel model = new ProductModel(_productManager.GetAllAsync().Result);
            return View("Products",model);
        }
    }
}
