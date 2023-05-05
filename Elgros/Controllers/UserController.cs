using Elgros.Models;
using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Elgros.Controllers
{
    /// <summary>
    /// Controller for user endpoints
    /// </summary>
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
        /// <summary>
        /// Displays cart
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Removes specific cart item from cart session data
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("/cart/removeitem")]
        public async Task<IActionResult> RemoveItemFromCart(int item)
        {
            string cartstring = _contextAccessor.HttpContext.Session.GetString("cart");
            string updatedcart = string.Empty;
            int cartcount = 0;

            List<string> cartids = cartstring.Split(",").ToList();
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
                _contextAccessor.HttpContext.Session.SetInt32("cartcount", cartcount);
                _contextAccessor.HttpContext.Session.SetString("cart", updatedcart);
            }
            return RedirectToAction("cart");
        }

        /// <summary>
        /// Displays order confirmed page
        /// </summary>
        /// <returns></returns>
        [HttpPost("/cart/orderconfirmed")]
        public async Task<IActionResult> OrderConfirmed()
        {
            return View("OrderConfirmed");
        }
        /// <summary>
        /// Displays login page
        /// </summary>
        /// <returns></returns>
        [HttpGet("/login")]
        public async Task<IActionResult> Login()
        {
            return View("Login");
        }
        /// <summary>
        /// Clears session from current user login
        /// </summary>
        /// <returns></returns>
        [HttpGet("/logud")]
        public async Task<IActionResult> Logud()
        {
            _contextAccessor.HttpContext.Session.Clear();
            return View("Login");
        }
        /// <summary>
        /// Get valid token if user login is true
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("user/confirm")]
        public async Task<IActionResult> ConfirmLogin(string username, string password)
        {
            try
            {
                int userid = await _userManager.CheckLogin(username, password);
                string userlogintoken = await _userManager.CreateUserToken(userid);
                _contextAccessor.HttpContext.Session.SetString("tkn", userlogintoken);
            }
            catch (Exception e)
            {
                _logger.LogError(e,null);
            }
            return RedirectToAction("cart");
        }
    }
}
