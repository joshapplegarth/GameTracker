using GameTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameTracker.Controllers
{
    public class LocationController : Controller
    {
        //FIELD & PROPERTIES ---------------------------------------------------------------------------
        private ILocationRepository _repository;
        private IUserRepository _userRepository;
        //CONSTRUCTOR ---------------------------------------------------------------------------
        public LocationController(ILocationRepository repository, IUserRepository userRepository) // Dependency Injection
                                                                  // Inversion of Control
        {
            _repository = repository;
            _userRepository = userRepository;

        }
        public IActionResult Index()
        {
            IQueryable<Location> allLocations = _repository.GetAllLocations();

            return View(allLocations);
        }

        // Methods -----------------------------------------------------------------------------------

        // Create -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Location
            { 
                UserId = _userRepository.GetLoggedInUserId()
            });
        }

        [HttpPost]
        public IActionResult Add(Location l)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(l);
                return RedirectToAction("Details", new { id = l.Id });
            }
            return View(l);
        }

        // Read -----------------------------------------------------------------------------------

        public IActionResult Details(int id)
        {
            Location l = _repository.GetLocationById(id);
            if (l == null)
            {
                return RedirectToAction("Index");
            }
            return View(l);
        }

        // Update -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Location l = _repository.GetLocationById(id);
            if (l == null)
            {
                return RedirectToAction("Index");
            }
            return View(l);
        }
        [HttpPost]
        public IActionResult Edit(Location l)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(l);
                return RedirectToAction("Details", new { id = l.Id });
            }
            return View(l);
        }

        // Delete -----------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Location l = _repository.GetLocationById(id);
            if (l != null)
            {
                return View(l);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Location l)
        {
            _repository.Delete(l.Id);
            return RedirectToAction("Index");
        }
    }
}
