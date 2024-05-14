using GunsOfTheOldWest.Ui.Mvc.Core;
using GunsOfTheOldWest.Ui.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GunsOfTheOldWest.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly GunsOfTheOldWestDbContext _gunsOfTheOldWestDbContext;
        public HomeController(GunsOfTheOldWestDbContext gunsOfTheOldWestDbContext)
        {
            _gunsOfTheOldWestDbContext = gunsOfTheOldWestDbContext;
        }

        // Define a property to store the number of bullets
        // We're tracking the bullets number in session
        // Reference: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-8.0
        private int Bullets
        {
            get
            {
                // Attempt to retrieve the number of bullets from the session, 12 by default
                return HttpContext.Session.GetInt32("Bullets") ?? 12;
            }
            set
            {
                // Store the number of bullets in the session
                HttpContext.Session.SetInt32("Bullets", value);
            }
        }

        public IActionResult Index()
        { 
            ViewBag.Bullets = Bullets;
            return View();
        }

        public IActionResult Reload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Fire()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10);

            Bullets--;

            ViewBag.RandomNumber = randomNumber;

            // No redirection needed when the number is higher than 3
            if (randomNumber > 3)
            {
                if (Bullets <= -1) // when the player has no more bullet left
                {
                    return RedirectToAction("Reload");
                }
                ViewBag.Bullets = Bullets;
                return View("Index");
            }

            // Redirect based on the random number and bullets count
            else if (randomNumber >= 0 && randomNumber <= 3) // when the player wins
            {
                if (Bullets <= -1) // when the player has no more bullet left
                {
                    return RedirectToAction("Reload");
                }
                return RedirectToAction("Index", "Winners");
            }
            
            
                
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BuyBullets(int numberOfBullets)
        {
            Bullets = numberOfBullets;

            // Redirect back to the main screen
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}