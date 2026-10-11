using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryManagement _context;

        public BooksController(LibraryManagement ctx)
        {
            _context = ctx;
        }
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
        }

        public ActionResult BooksCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BooksCreate(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("BooksCreate", book);
        }

        public ActionResult Edit(int id)
        {
            var book = (from b in _context.Books
                        where b.Id == id
                        select b
                        ).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var data = (from b in _context.Books
                        where b.Id == book.Id
                        select b).FirstOrDefault();

            data.Name = book.Name;
            data.Price = book.Price;
            data.AuthorId = book.AuthorId;

            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            var book = (from b in _context.Books
                        where b.Id == id
                        select b).FirstOrDefault();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
