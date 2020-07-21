using Microsoft.AspNetCore.Mvc;

namespace SnackSales.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}