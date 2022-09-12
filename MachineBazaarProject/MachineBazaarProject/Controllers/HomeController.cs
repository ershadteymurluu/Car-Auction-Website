using MachineBazaar.DAL;
using MachineBazaar.Models;
using MachineBazaar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MachineBazaar.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db { get; }
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                bodyStyles = await _db.bodyStyles.ToListAsync(),
                transmissions = await _db.transmissions.ToListAsync(),
                years = await _db.years.ToListAsync(),
                Cars = await _db.cars.Include(item => item.Images).Include(item => item.MotorSize).
                Include(item => item.Year).
                Include(item => item.Transmission).
                Include(item => item.CarBids).
                ToListAsync()
            };
            return View(hvm);
        }

        [HttpPost]
        public async Task<IActionResult> ExpireAuction(bool status, int id)
        {
            Car? car = await _db.cars.FirstOrDefaultAsync(item => item.Id == id);
            car.Status = status;
            _db.cars.Update(car);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> NewListed()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                Cars = await _db.cars.
                Where(item => item.EndTime.Day - DateTime.Now.Day == 2).
                Include(item => item.Images).
                Include(item => item.Year).Include(item => item.MotorSize).
                Include(item => item.Transmission).
                Include(item => item.CarBids).
                ToListAsync()
            };
            return PartialView("_CarPartial", hvm);
        }


        [HttpGet]
        public async Task<IActionResult> EndingSoon()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                Cars = await _db.cars.
                Include(item => item.Images).
                Include(item => item.Year).
                Include(item => item.Transmission).Include(item => item.MotorSize).
                Include(item => item.CarBids).
                ToListAsync()
            };
            return PartialView("_CarPartial", hvm);
        }


        [HttpGet]
        public async Task<IActionResult> LowestMileage()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                Cars = await _db.cars.
                Where(item => item.Mileage < 10000).
                Include(item => item.Images).
                Include(item => item.Year).
                Include(item => item.Transmission).Include(item => item.MotorSize).
                Include(item => item.CarBids).
                ToListAsync()
            };
            return PartialView("_CarPartial", hvm);
        }
        [HttpGet]
        public async Task<IActionResult> SearchEngine(string query)
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                Cars = await _db.cars.Include(item => item.Images).
                Include(item => item.MotorSize).
                Include(item => item.Year).
                Include(item => item.Transmission).
                Include(item => item.CarBids).Where(item => item.Make.ToLower().Contains(query.ToLower())).ToListAsync()
            };

            return PartialView("_CarPartial", hvm);
        }

        public async Task<IActionResult> ShowPastResults()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                bodyStyles = await _db.bodyStyles.ToListAsync(),
                transmissions = await _db.transmissions.ToListAsync(),
                years = await _db.years.ToListAsync(),
                Cars = await _db.cars.Include(item => item.Images).
                Include(item => item.Year).
                Include(item => item.Transmission).
                Include(item => item.CarBids).
                ToListAsync()
            };
            return View(hvm);
        }
    }
}