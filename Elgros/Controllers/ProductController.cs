using Elgros.Models;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using MySqlX.XDevAPI;

namespace Elgros.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductController(ILogger<ProductController> logger, IProductManager productmanager, IHttpContextAccessor contextAccessor)
        {
            _productManager = productmanager;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("/products")]
        public async Task<IActionResult> Products()
        {
            ProductModel productmodel = new ProductModel(_productManager.GetAllAsync().Result);
            GlobalModel model = new GlobalModel();
            model.productModel = productmodel;
            return View("Products", model);
        }

        [HttpPost("/products/saveitem")]
        public async Task<IActionResult> AddItemToCart(int item)
        {
            string cart = _contextAccessor.HttpContext.Session.GetString("cart");
            cart += item + ",";
            _contextAccessor.HttpContext.Session.SetString("cart", cart);
            try
            {
                int cartcount = (int)_contextAccessor.HttpContext.Session.GetInt32("cartcount");
                _contextAccessor.HttpContext.Session.SetInt32("cartcount", cartcount + 1);

            }
            catch (Exception)
            {
                _contextAccessor.HttpContext.Session.SetInt32("cartcount", 1);
            }
            return RedirectToAction("Products");
        }
       
    }
}
