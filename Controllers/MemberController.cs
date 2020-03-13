﻿using System;
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
        

        //Constructor
        public MemberController(ILogger<BooksController> logger, IMemberFetcher fetchService)
        {
            _logger = logger;
            _fetchService = fetchService;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}