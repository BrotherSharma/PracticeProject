using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class MVCStudentController : Controller
    {
        private readonly ILogger<MVCStudentController> _logger;

        public MVCStudentController(ILogger<MVCStudentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [Route("Update")]
        [HttpGet("{id}")]
        
        public IActionResult Update(int id = 0)
       {
         ViewBag.id = id;
        return View(id);
       }
       
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}