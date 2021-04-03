using System;
using Microsoft.AspNetCore.Mvc;
using Hello.ViewModel;

namespace Hello.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            throw new InvalidProgramException("Bad Things happen for one's good"); // Purposely created error
            return View();
        }

        [HttpGet("Earth")]
        public IActionResult Earth()
        {
            return View();
        }

        [HttpPost("Earth")]
        public IActionResult Earth(ContactViewModel model)
        {
            return View();
        }

        public IActionResult Mars()
        {
            return View();
        }
    }
}