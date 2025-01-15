using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Data;
using BookstoreApp.Models;

namespace BookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUserAuthenticationService _authService;

        public BooksController(IUserAuthenticationService authService)
        {
            _authService = authService;
        }

        private static List<Book> _books = new List<Book>
        { 
            new Book { Id = 1, Title = "Book 1", Author = "Author 1" , Price = 9.99m},
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Price = 14.99m}

        };

        //list books
        public IActionResult Index()
        {
            return View(_books);
        }

        //display form to add new books
        public IActionResult Create()
        {
            if (!_authService.IsAuthenticated()) return RedirectToAction("Login", "User");
            return View();
        }

        //add new book to list
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!_authService.IsAuthenticated()) return RedirectToAction("Login", "User");
            book.Id = _books.Count + 1; //auto increment
            _books.Add(book);
            return RedirectToAction(nameof(Index));
        }

        //Display a form to edit a book
        public IActionResult Edit(int id)
        {
            if (!_authService.IsAuthenticated()) return RedirectToAction("Login", "User");

            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        //update book in list
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!_authService.IsAuthenticated()) return RedirectToAction("Login", "User");

            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null) return NotFound();

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            return RedirectToAction(nameof(Index));
        }

        //delete book
        public IActionResult Delete(int id, Book book)
        {
            if (!_authService.IsAuthenticated()) return RedirectToAction("Login", "User");
            var books = _books.FirstOrDefault(b => b.Id == id);
            if (books == null) return NotFound();

            _books.Remove(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
