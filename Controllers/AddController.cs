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
    public class AddController : Controller
    {
        private readonly IAdder _myService;
        public AddController(IAdder myService)
        {
            _myService = myService;
            
        }
        private readonly ILogger<SearchController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook(Book newBook)
        {
            _myService.AddBook(newBook);
            return View();
        }
        
        
    }
}