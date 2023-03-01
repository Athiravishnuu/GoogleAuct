using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoogleAuct.Controllers;
public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action(nameof(GoogleCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(
                GoogleDefaults.AuthenticationScheme, redirectUrl);
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(SignIn));
            }

            var claims = result.Principal.Claims;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
           

            
            return RedirectToAction("Index", "Home");
        }
    }











//public class AccountController : Microsoft.AspNetCore.Mvc.Controller
//{

//    [HttpGet]
//    public IActionResult SignIn()
//    {
//        var redirectUrl = Url.Action(nameof(GoogleCallback), "Account");
//        var properties = .ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme, redirectUrl);
//        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
//    }

//    [HttpGet]
//    public async Task<IActionResult> GoogleCallback()
//    {
//        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        if (!result.Succeeded)
//        {
//            return RedirectToAction(nameof(SignIn));
//        }

//        var claims = result.Principal.Claims;
//        var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

//        // Use email to sign user in or create a new user in your system

//        return RedirectToAction("Index", "Home");
//    }
//}

//private readonly ILogger<HomeController> _logger;

//public HomeController(ILogger<HomeController> logger)
//{
//    _logger = logger;
//}

//public IActionResult Index()
//{
//    return View();
//}

//public IActionResult Privacy()
//{
//    return View();
//}

//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//public IActionResult Error()
//{
//    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//}

//}