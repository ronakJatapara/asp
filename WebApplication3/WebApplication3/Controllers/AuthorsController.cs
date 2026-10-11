using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly LibraryManagement _context;

        public AuthorsController(LibraryManagement ctx)
        {
            _context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AuthorCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AuthorCreate(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(AuthorCreate));
            }
            return View(author);
        }
    }
}
