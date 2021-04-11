using System;
using Microsoft.AspNetCore.Mvc;
using Hello.ViewModel;
using Hello.Services;
using Hello.Data;
using System.Linq;

namespace Hello.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogService logservice;
        private readonly IHelloRepository repository;

        public AppController(ILogService logService, IHelloRepository repository)
        {
            this.logservice = logService;
            this.repository = repository;
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
                logservice.SaveRequest(model.FirstName,model.LastName,model.Reason);
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
        
        public IActionResult Shop()
        {
            // var results = context.Products.OrderBy(p => p.Category).ToList(); // fluent syntax
            var results = repository.GetAllProducts();
            
            return View(results);
        }
    }
}