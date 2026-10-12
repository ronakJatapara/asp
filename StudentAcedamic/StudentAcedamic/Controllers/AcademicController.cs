using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAcedamic.Data;
using StudentAcedamic.Models;
using StudentAcedamic.ViewModels;

namespace StudentAcedamic.Controllers
{
    public class AcademicController : Controller
    {
        private readonly ApplicationDbContext db;

        public AcademicController(ApplicationDbContext db)
        {
            this.db = db;
        }
        //List
        [HttpGet]
        public IActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentMarksViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            //total
            int total =
                model.Maths +
                model.English +
                model.Science +
                model.Computer;

            //precentage
            double percentage = total / 4.0;

            //result

            string result =
                model.Maths >= 35 &&
                model.Science >= 35 &&
                model.English >= 35 &&
                model.Computer >= 35 ? "Pass" : "Fail";
            //Student table
            Student student = new Student
            {
                Name = model.Name,
                RollNo = model.RollNo,
                Course = model.Course
            };
            db.Students.Add(student);
            db.SaveChanges();

            //Mark table
            Mark mark = new Mark
            {
                StudentId = student.Id,

                Maths = model.Maths,
                Science = model.Science,
                English = model.English,
                Computer = model.Computer,

                Total = total,
                Percentage = percentage,
                Result = result


            };
            db.Marks.Add(mark);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Report
        [HttpGet]
        public IActionResult Report(string search,string resultFilter)
        {
            var report = db.Students
                .Include(s => s.Mark)
                .AsQueryable();

            //search by name or rollno
            if(!string.IsNullOrEmpty(search))
            {
                report = report.Where(s =>
                s.Name.Contains(search) ||
                s.RollNo.Contains(search)
                );
            }

            //Filter by result
            if(!string.IsNullOrEmpty(resultFilter)&&resultFilter!="All")
            {
                report = report.Where(s => s.Mark.Result == resultFilter);

            }

            var data = report.ToList();

            return View(data);


        }

    }
}
