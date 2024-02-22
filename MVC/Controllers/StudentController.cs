using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVC.Repositories;
using MVC.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepositories _studentrepo;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentRepositories studentrepo)
        {
            _logger = logger;
            _studentrepo = studentrepo;
        }

        public IActionResult Index()
        {
        //     string username = HttpContext.Session.GetString("username");
        //    // ViewBag.UserName = HttpContext.Session.GetString("c_username");
        //     if(username==null)
        //     {
        //         return RedirectToAction("Login","User");
        //     }

            //ViewBag.UserName = username;
            List<tblstudent> studlist = _studentrepo.GetAll();
            return View(studlist);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
             string username = HttpContext.Session.GetString("UserName");
            // ViewBag.UserName = HttpContext.Session.GetString("c_username");
            // if(username==null)
            // {
            //     return RedirectToAction("Login","User");
            // }

             ViewBag.UserName = username;
            var students = _studentrepo.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            // if(HttpContext.Session.GetString("username")==null)
            // {
            //     return RedirectToAction("Login","User");
            // }
            var courses = _studentrepo.GetCourseNames();
            ViewBag.Courses = new SelectList(courses, "CourseID", "CourseName");

            return View();
        }

        [HttpPost]
        public IActionResult Insert(tblstudent student)
        {
            _studentrepo.Insert(student);
            return RedirectToAction("GetAllStudents");
        }

        [HttpGet]
        public IActionResult GetStudentDetails(int id)
        {
            // if(HttpContext.Session.GetString("username")==null)
            // {
            //     return RedirectToAction("Login","User");
            // }
            var student = _studentrepo.GetOne(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // [HttpGet]
        // public IActionResult GetStudentDetailsByEmail(string email)
        // {
        //     // if(HttpContext.Session.GetString("username")==null)
        //     // {
        //     //     return RedirectToAction("Login","User");
        //     // }
        //     var student = _studentHelper.FetchStudentDetailsByEmail(email);
        //     if (student == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(student);
        // }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            // if(HttpContext.Session.GetString("username")==null)
            // {
            //     return RedirectToAction("Login","User");
            // }
            
            var courses = _studentrepo.GetCourseNames();

        // Populate ViewBag.Courses with the courses collection
        ViewBag.Course = courses;

        var student = _studentrepo.GetOne(id);
        return View(student);

        }

        
        
        [HttpPost]
        public IActionResult UpdateStudent(tblstudent student)
        {
             
            _studentrepo.Update(student);
            return RedirectToAction("GetAllStudents");
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            // if(HttpContext.Session.GetString("username")==null)
            // {
            //     return RedirectToAction("Login","User");
            // }
            var student = _studentrepo.GetOne(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudentConfirmed(int id)
        {
            _studentrepo.Delete(id);
            return RedirectToAction("GetAllStudents");
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
