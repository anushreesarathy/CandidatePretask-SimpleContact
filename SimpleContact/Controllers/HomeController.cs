using Microsoft.AspNetCore.Mvc;
using SimpleContact.Models;
using System.Diagnostics;
using SimpleContact.Services;


namespace SimpleContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult Index(SimpleContact.Models.Email email )
        {
            _emailService.SendContactEmail(email.Name, email.Email, email.Message);
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
    }
}