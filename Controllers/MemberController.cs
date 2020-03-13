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
    
        public class MemberController : Controller
        {
            //Services
            private readonly ILogger<BooksController> _logger;
            private readonly IFetcher _myService;
            private readonly ICopyUpdater _copyUpdaterService;
            private readonly IAdder _adderService;
         
            //Constructor
            public MemberController(IFetcher myService, ICopyUpdater copyUpdaterService, IAdder adderService, ILogger<BooksController> logger)
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
            
            
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
            }
    
}