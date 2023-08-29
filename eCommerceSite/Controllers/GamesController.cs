﻿using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class GamesController : Controller 
    {
        private readonly VideoGameContext _context;

        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game g)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(g);
                _context.SaveChanges();

                ViewData["Message"] = $"{g.Title} was added successfully!";
                return View();
            }
            return View(g);
        }
    }
}