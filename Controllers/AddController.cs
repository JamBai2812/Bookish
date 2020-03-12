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
        private readonly ILogger<SearchController> _logger;
        
        // private readonly IService _myService;
        //
        // public SearchController(IService myService)
        // {
        //     _myService = myService;
        // }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            return View();
        }
        
        
    }
}