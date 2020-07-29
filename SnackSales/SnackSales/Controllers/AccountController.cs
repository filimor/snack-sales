using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnackSales.ViewModels;

namespace SnackSales.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.Username).ConfigureAwait(false);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false)
                    .ConfigureAwait(false);
                if (result.Succeeded)
                {
                    return string.IsNullOrEmpty(loginViewModel.ReturnUrl)
                        ? RedirectToAction("Index", "Home")
                        : RedirectToAction(loginViewModel.ReturnUrl);
                }

                ModelState.AddModelError("", "Usuário ou senha inválidos.");
            }

            return View(loginViewModel);
        }
    }
}