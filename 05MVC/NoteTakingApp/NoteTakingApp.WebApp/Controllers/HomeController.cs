﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteTakingApp.Domain;
using NoteTakingApp.WebApp.Models;

namespace NoteTakingApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var notes = _repo.GetNotes();
            // ways to get data from controller to the view:
            //  - pass an object as the "model" parameter of the View method.
            //       it is visible as "Model" within the view.
            //  - ViewData (dictionary of string to object)
            //  - also, ViewBag and TempData

            // views can have a @model directive at the top,
            // making them "strongly-typed" as opposed to dynamically/weakly-typed.
            // - meaning, you have to pass the right data type of object to the view.

            // web developers culturally prefer dynamically typed stuff more
            // so than backend developers
            ViewData["key"] = "value";
            return View(model: notes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
