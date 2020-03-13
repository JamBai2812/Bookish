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
        private readonly IMemberFetcher _fetchService;
        private readonly ICheckOut _checkOutService;


        //Constructor
        public MemberController(ILogger<BooksController> logger, IMemberFetcher fetchService, ICheckOut checkOutService)
        {
            _logger = logger;
            _fetchService = fetchService;
            _checkOutService = checkOutService;
        }

        //Actions
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult AllOrderById()
        {
            var data = _fetchService.AllMembers("SELECT * FROM members");
            var model = new Members(data);
            return View(model);
        }
        public IActionResult CheckOutForm()
        {
            return View();
        }

        public IActionResult CheckOutBook([FromForm] MemberBook newMemberBook)

        {
            _checkOutService.AddMemberBook(newMemberBook);
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}