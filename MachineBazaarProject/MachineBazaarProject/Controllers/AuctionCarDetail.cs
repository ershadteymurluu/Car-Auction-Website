using MachineBazaar.DAL;
using MachineBazaar.Models;
using MachineBazaar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBazaar.Controllers
{
    public class AuctionCarDetail : Controller
    {
        private AppDbContext _db { get; }
        private UserManager<AppUser> _userManager { get; }
        public AuctionCarDetail(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int id)
        {
            Car? car = await _db.cars.Include(element => element.Images).Include(item => item.Year).
             Include(item => item.Transmission).
             Include(item => item.BodyStyle).
             Include(item => item.FuelType).
             Include(item => item.AppUser).
             Include(item=>item.MotorSize).
             Include(item => item.Comments).
             ThenInclude(item => item.User).
             ThenInclude(item => item.MyBids).
             Include(element => element.CarBids).
             FirstOrDefaultAsync(item => item.Id == id);

            TempData["Bids"] = (await _db.cars.Include(element => element.CarBids).ThenInclude(element => element.User).FirstOrDefaultAsync(item => item.Id == id)).CarBids.Select(item => item.User).Distinct().Count();

            CommentViewModel viewModel = new CommentViewModel()
            {
                Car = car,
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(CommentViewModel viewModel)
        {
            viewModel.Car = await _db.cars.Include(element => element.Images).Include(item => item.Year).
             Include(item => item.Transmission).
             Include(item => item.BodyStyle).
             Include(item => item.FuelType).
             Include(item => item.AppUser).
             Include(item => item.MotorSize).
             Include(item => item.Comments).
             ThenInclude(item => item.User).
             ThenInclude(item => item.MyBids).
             Include(element => element.CarBids).
             FirstOrDefaultAsync(item => item.Id == viewModel.GetCarId);

            TempData["Bids"] = (await _db.cars.Include(element => element.CarBids).ThenInclude(element => element.User).FirstOrDefaultAsync(item => item.Id == viewModel.GetCarId)).CarBids.Select(item => item.User).Distinct().Count();
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            Comments Comment = new Comments()
            {
                CommentText = viewModel.CommentText,
                CarId = viewModel.GetCarId,
                User = await _userManager.FindByNameAsync(User.Identity.Name),
                CommentDate = DateTime.Now.ToString("dd MMM yyyy hh:mm tt")
            };
            _db.comments.Add(Comment);
            _db.SaveChangesAsync();
            return RedirectPermanent("/auctioncardetail/Index/" + viewModel.GetCarId);
        }
        public async Task<IActionResult> ViewDetails(int id)
        {
            Car? car = await _db.cars.
                Include(item => item.CarBids).
                ThenInclude(item => item.User).
                FirstOrDefaultAsync(element => element.Id == id);

            ViewBag.DistincBids = car.CarBids.OrderByDescending(item => item.Bid).Select(item => item.User).Distinct();
            ViewBag.Counter = 1;
            return View(car);
        }
    }
}
