using MachineBazaar.DAL;
using MachineBazaar.Models;
using MachineBazaar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBazaar.Controllers
{
    public class Bid : Controller
    {
        private AppDbContext _db { get; }
        private UserManager<AppUser> _userManager { get; }
        public Bid(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> PlaceBid(int id)
        {
            Car? carToBid = await _db.cars.Include(element => element.Year).
                Include(element => element.Images).
                Include(element => element.FuelType).
                Include(element => element.BodyStyle).
                Include(element => element.Transmission).
                Include(element => element.MotorSize).
                 Include(element => element.CarBids).
                FirstOrDefaultAsync(car => car.Id == id);
            BidViewModel viewModel = new BidViewModel()
            {
                Car = carToBid
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceBid(BidViewModel viewModel)
        {
            viewModel.Car = await _db.cars.Include(element => element.Year).
                Include(element => element.Images).
                Include(element => element.FuelType).
                Include(element => element.BodyStyle).
                Include(element => element.Transmission).
                Include(element => element.MotorSize).
                Include(element=>element.CarBids).
                FirstOrDefaultAsync(car => car.Id == viewModel.GetCarId);
            if (viewModel.Bid == null)
            {
                ModelState.AddModelError("Bid", "Can't add an empty value.");
            }

            else if (viewModel.Bid != null && Int32.Parse(viewModel.Bid) <= 0)
            {
                ModelState.AddModelError("Bid", "Can't add a bid less than or equal to zero");
            }
            else if (viewModel.Car.CarBids.Count == 0 && viewModel.Bid != null && Int32.Parse(viewModel.Bid) <= viewModel.Car.AuctionStartingPrice)
            {
                ModelState.AddModelError("Bid", "Bid must be greater than the car's starting auction price. ");
            }
            else if (viewModel.Car.CarBids.Count > 0 && Int32.Parse(viewModel.Bid) <= viewModel.Car.CarBids[viewModel.Car.CarBids.Count-1].Bid)
            {
                ModelState.AddModelError("Bid", "Bid must be greater than the highest bid");
            }
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            Bids newBid = new Bids()
            {
                Bid = Int32.Parse(viewModel.Bid),
                CarId = viewModel.GetCarId,
                User = await _userManager.FindByNameAsync(User.Identity.Name)
            };
            await _db.bids.AddAsync(newBid);
            await _db.SaveChangesAsync();
            return Redirect("/auctioncardetail/index/" + viewModel.GetCarId);
        }
    }
}
