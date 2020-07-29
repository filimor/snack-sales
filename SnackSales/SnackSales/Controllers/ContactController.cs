using Microsoft.AspNetCore.Mvc;

namespace SnackSales.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            //return User.Identity.IsAuthenticated ? View() : (IActionResult)RedirectToAction("Login", "Account");
            return View();
        }
    }
}