using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpaceSystemWeb.Data;
using SpaceSystemWeb.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SpaceSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRolesService _userRolesService;

        public HomeController(ILogger<HomeController> logger, IUserRolesService userRolesService)
        {
            _logger = logger;
            _userRolesService = userRolesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected async Task<string> GetCurrentUserEmail()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return email;
        }

        public async Task<IActionResult> EnsureRolesAndUsers()
        {
            var email = GetCurrentUserEmail().Result;
            await _userRolesService.EnsureAdminUserRole(email);
            return RedirectToAction("Index");
        }
    }
}