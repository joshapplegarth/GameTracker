using GameTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker.Controllers
{
    public class GameController : Controller
    {
        //FIELD & PROPERTIES ---------------------------------------------------------------------------
        private IGameRepository _repository;
        //CONSTRUCTOR ---------------------------------------------------------------------------
        public GameController(IGameRepository repository) // Dependency Injection
                                                          // Inversion of Control
        {
            _repository = repository;
        }
        //public IActionResult Index(int )
        //{
        //    IQueryable<Game> allGames = _repository.GetAllGames();
        //
        //    return View(allGames);
        //}

        // Methods -----------------------------------------------------------------------------------

        // Create -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Add(int locationId)
        {
            Game g = new Game { LocationId = locationId };
            return View(g);
        }

        [HttpPost]
        public IActionResult Add(Game g)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(g);
                return RedirectToAction("Details", new { id = g.Id });
            }
            return View(g);
        }

        // Read -----------------------------------------------------------------------------------

        public IActionResult Details(int id)
        {
            Game g = _repository.GetGameById(id);
            if (g == null)
            {
                return RedirectToAction("Index", "Location");
            }
            return View(g);
        }

        // Update -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Game g = _repository.GetGameById(id);
            return View(g);
        }
        [HttpPost]
        public IActionResult Edit(Game g)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(g);
                return RedirectToAction("Details", new { id = g.Id });
            }
            return View(g);
        }

        // Delete -----------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Game g = _repository.GetGameById(id);
            if (g != null)
            {
                return View(g);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Game g)
        {
            int locationId = g.LocationId;
            _repository.Delete(g);
            return RedirectToAction("Details", "Location", new { id = locationId });
        }
    }
}
