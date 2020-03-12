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
    public interface IFetcher
    {
        List<Book> BookListQuery(string sql);
    }
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IFetcher _myService;

        public SearchController(IFetcher myService)
        {
            _myService = myService;
            
        }

        // public SearchController(ILogger<SearchController> logger)
        //             {
        //                 _logger = logger;
        //             }
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult AllOrderByAuthorLastName(string sql)
        {
            var data = _myService.BookListQuery("SELECT * FROM catalogue ORDER BY author_last_name");
            var model = new Catalogue(data);
            return View(model);
        }
        public IActionResult AllOrderByYearDesc()
        {
            var data = _myService.BookListQuery("SELECT * FROM catalogue ORDER BY year_published DESC");
            var model = new Catalogue(data);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}