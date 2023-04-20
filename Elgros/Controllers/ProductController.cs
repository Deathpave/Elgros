﻿using Elgros.Models;
using ElgrosLib.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ProductModel model = new ProductModel(_productManager.GetAllAsync().Result);
            return View("Products", model);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddItemToCart()
        //{
        //    string cart = _contextAccessor.HttpContext.Session.GetString("cart");
        //    _contextAccessor.HttpContext.Session.SetString("cart",cart);

        //}
    }
}
