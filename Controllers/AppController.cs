using System;
using Microsoft.AspNetCore.Mvc;
using Hello.ViewModel;
using Hello.Services;

namespace Hello.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogService _logservice;
        public AppController(ILogService logService)
        {
            _logservice = logService;
        }

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
            if(ModelState.IsValid)
            {
                // Save Request
                _logservice.SaveRequest(model.FirstName,model.LastName,model.Reason);
                ViewBag.UserMessage = "Request Saved";
                ModelState.Clear();
            }
            else
            {
                // Throw Error
            }
            return View();
        }

        public IActionResult Mars()
        {
            return View();
        }
    }
}