using Microsoft.AspNetCore.Mvc;

namespace Elgros.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/cart")]
        public async Task<IActionResult> Cart()
        {

            return View("Cart");
        }
    }
}
