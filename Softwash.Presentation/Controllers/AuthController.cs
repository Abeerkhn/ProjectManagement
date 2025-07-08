using Microsoft.AspNetCore.Mvc;

namespace Softwash.Presentation.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }


    }
}
