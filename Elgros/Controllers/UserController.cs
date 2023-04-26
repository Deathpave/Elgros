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
        private readonly IUserManager _userManager;

        public UserController(ILogger<UserController> logger, IHttpContextAccessor contextAccessor, IProductManager productManager, IUserManager userManager)
        {
            _productManager = productManager;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _userManager = userManager; 
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
                    if (product != "")
                    {
                        ProductList.Add(await _productManager.GetByIdAsync(int.Parse(product)));

                    }
                }
                datamodel.Products = ProductList;
            }
            return View("Cart", datamodel);
        }

        [HttpPost("/cart/removeitem")]
        public async Task<IActionResult> RemoveItemFromCart(int item)
        {
            string cartstring = _contextAccessor.HttpContext.Session.GetString("cart");
            List<string> cartids = cartstring.Split(",").ToList();
            string updatedcart = string.Empty;
            int cartcount = 0;
            if (cartids.Count > 0)
            {
                foreach (string cartid in cartids)
                {
                    if (cartid != item.ToString() && cartid != "")
                    {
                        updatedcart += cartid + ",";
                        cartcount++;
                    }
                }
                _contextAccessor.HttpContext.Session.SetInt32("cartcount",cartcount);
                _contextAccessor.HttpContext.Session.SetString("cart", updatedcart);
            }
            return RedirectToAction("cart");
        }

        //[HttpPost("/cart/order")]
        //public async Task<IActionResult> Order()
        //{

        //}

        [HttpGet("/login")]
        public async Task<IActionResult> Login()
        {
            return View("Login");
        }

        [HttpPost("login/confirm")]
        public async Task<IActionResult> ConfirmLogin(string username,string password)
        {
            _userManager.CheckLogin(username, password);
            return View("Login");
        }
    }
}
