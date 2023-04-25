using Elgros.Models;
using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Elgros.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductManager _productManager;

        public UserController(ILogger<UserController> logger, IHttpContextAccessor contextAccessor,IProductManager productManager)
        {
            _productManager = productManager;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("/cart")]
        public async Task<IActionResult> Cart()
        {
            List<Product> ProductList = new List<Product>();
            ProductModel datamodel = new ProductModel(ProductList);
            if (_contextAccessor.HttpContext.Session.Keys.Contains("cart"))
            {
                string productstring = _contextAccessor.HttpContext.Session.GetString("cart");
                string[] products = productstring.Split(",");
                IEnumerable<Product> ProductEnum;
                
                foreach (string product in products)
                {
                    ProductList.Add(await _productManager.GetByIdAsync(int.Parse(product)));
                }
                datamodel.Products = ProductList;
            }
            return View("Cart",datamodel);
        }
    }
}
