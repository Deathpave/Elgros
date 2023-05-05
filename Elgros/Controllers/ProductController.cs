using Elgros.Models;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using MySqlX.XDevAPI;

namespace Elgros.Controllers
{
    /// <summary>
    /// Controller for product endpoints
    /// </summary>
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

        /// <summary>
        /// Show all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("/products")]
        public async Task<IActionResult> Products()
        {
            ProductModel model = new ProductModel(await _productManager.GetAllAsync());
            return View("Products", model);
        }

        /// <summary>
        /// Save specific item to cart
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
