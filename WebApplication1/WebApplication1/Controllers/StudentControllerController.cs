
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Student s)
        {
            if (!ModelState.IsValid)
            {
                return View(students);
            }

            s.Total = s.Sub1 + s.Sub2 + s.Sub3
                    + s.Sub4 + s.Sub5;

            s.Percentage = s.Total / 5.0;

            if (s.Sub1 >= 35 && s.Sub2 >= 35 &&
                s.Sub3 >= 35 && s.Sub4 >= 35 &&
                s.Sub5 >= 35)
            {
                s.Result = "Pass";
            }
            else
            {
                s.Result = "Fail";
            }

            students.Add(s);

            return RedirectToAction("Index");
        }
    }
}
