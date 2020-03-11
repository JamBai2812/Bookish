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

namespace Bookish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [HttpGet("my-route")]
        public IActionResult Index()
        {
            return View("Index");
        }

        // [HttpGet("my-privacy")]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Search()
        {
            var fetcher = new BookFetcher();
            var sql = "SELECT * FROM catalogue";
            var sql2 = "SELECT * FROM catalogue ORDER BY year_published";
            var data = fetcher.BookListQuery(sql2);
            var catalogue = new Catalogue(data);
            return View(catalogue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}