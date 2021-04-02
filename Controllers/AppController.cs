using System;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            // throw new InvalidProgramException("Bad Things happen for one's good"); // Purposely created error
            return View();
        }

        public IActionResult Earth()
        {
            return View();
        }

        public IActionResult Mars()
        {
            return View();
        }
    }
}