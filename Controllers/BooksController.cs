using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookish.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Models.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Bookish.Controllers
{
    
    public class BooksController : Controller
             {
                 //Services
                 private readonly ILogger<BooksController> _logger;
                 private readonly IFetcher _myService;
                 private readonly ICopyUpdater _copyUpdaterService;
                 private readonly IAdder _adderService;
         
                 //Constructor
                 public BooksController(IFetcher myService, ICopyUpdater copyUpdaterService, IAdder adderService, ILogger<BooksController> logger)
                 {
                     _myService = myService;
                     _copyUpdaterService = copyUpdaterService;
                     _adderService = adderService;
                     _logger = logger;
                 }
                 
                 //Actions
                 public IActionResult Search()
                 {
                     return View("Index");
                 }
        
        public IActionResult AddBookForm()
        {
            return View();
        }

        public IActionResult AddBook([FromForm]Book newBook)
        {
            _adderService.AddBook(newBook);
            return View();
        }
        public IActionResult AllOrderByAuthorLastName()
        {
            var data = _myService.BookListQuery("SELECT * FROM catalogue ORDER BY author_last_name");
            var model = new Catalogue(data);
            return View("AllOrderByAuthorLastName", model);
        }
        public IActionResult AllOrderByYearDesc()
        {
            var data = _myService.BookListQuery("SELECT * FROM catalogue ORDER BY year_published DESC");
            var model = new Catalogue(data);
            return View(model);
        }

        public IActionResult AddCopy(string id)
        {
            _copyUpdaterService.AddCopy(id);
            return AllOrderByAuthorLastName();
        }
        
        public IActionResult DeleteCopy(string id)
        {
            _copyUpdaterService.DeleteCopy(id);
            return AllOrderByAuthorLastName();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}