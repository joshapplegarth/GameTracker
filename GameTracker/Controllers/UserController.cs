using GameTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameTracker.Controllers
{
    public class UserController : Controller
    {
        //FIELD & PROPERTIES ---------------------------------------------------------------------------
        private IUserRepository _repository;
        //CONSTRUCTOR ---------------------------------------------------------------------------
        public UserController(IUserRepository repository) // Dependency Injection
                                                          // Inversion of Control
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            IQueryable<User> allUsers = _repository.GetAllUsers();

            return View(allUsers);
        }

        // Methods -----------------------------------------------------------------------------------

        // Create -----------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel urvm)
        {
            if (ModelState.IsValid)
            {
                User u = new User();
                
                u.Firstname = urvm.Firstname;
                u.Lastname = urvm.Lastname;
                u.Email = urvm.Email;
                u.Password = urvm.Password;
                u.IsAdmin = false;


                User newUser = _repository.Create(u);
                if (newUser == null)
                {
                    ModelState.AddModelError("", "This Use Already Exists.");
                    return View(urvm);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(urvm);
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}
        //
        //[HttpPost]
        //public IActionResult Add(User u)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.Create(u);
        //        return RedirectToAction("Details", new { id = u.UserId });
        //    }
        //    return View(u);
        //}

        // Read -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            bool loggedIn = _repository.Login(u);
            if (loggedIn == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult Details(int id)
        //{
        //    User u = _repository.GetUserById(id);
        //    return View(u);
        //}

        // Update -----------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePasswordViewModel ucpvm)
        {
            if (ModelState.IsValid)
            {
                bool success =
                   _repository.ChangePassword(ucpvm.CurrentPassword, ucpvm.NewPassword);
                if (success == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Unable To Change Password");
                return View(ucpvm);
            }

            return View(ucpvm);

            //[HttpGet]
            //public IActionResult Edit(int id)
            //{
            //    User u = _repository.GetUserById(id);
            //    return View(u);
            //}
            //[HttpPost]
            //public IActionResult Edit(User u)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _repository.Update(u);
            //        return RedirectToAction("Details", new { id = u.UserId });
            //    }
            //    return View(u);
            //}

            // Delete -----------------------------------------------------------------------------------
            //[HttpGet]
            //public IActionResult Delete(int id)
            //{
            //    User u = _repository.GetUserById(id);
            //    if (u != null)
            //    {
            //        return View(u);
            //    }
            //    return RedirectToAction("Index");
            //}
            //[HttpPost]
            //public IActionResult Delete(User u)
            //{
            //    _repository.Delete(u.UserId);
            //    return RedirectToAction("Index");
            //}
        }
    }
}
