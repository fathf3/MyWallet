using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
