using GunsOfTheOldWest.Ui.Mvc.Core;
using GunsOfTheOldWest.Ui.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GunsOfTheOldWest.Ui.Mvc.Controllers
{
    public class WinnersController : Controller
    {
        private readonly GunsOfTheOldWestDbContext _gunsOfTheOldWestDbContext;
        public WinnersController(GunsOfTheOldWestDbContext gunsOfTheOldWestDbContext)
        {
            _gunsOfTheOldWestDbContext = gunsOfTheOldWestDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Summary()
        {
            var winners = _gunsOfTheOldWestDbContext.Winners.ToList();
            return View(winners);
        }

        [HttpPost]
        public IActionResult Register(Winner winner)
        {
            _gunsOfTheOldWestDbContext.Winners.Add(winner);
            _gunsOfTheOldWestDbContext.SaveChanges();

            return RedirectToAction("Summary");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
