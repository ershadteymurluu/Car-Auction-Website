using MachineBazaar.DAL;
using MachineBazaar.Models;
using MachineBazaar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBazaar.Controllers
{
    [Authorize]
    public class SellYourCar : Controller
    {
        private AppDbContext _db { get; }
        private UserManager<AppUser> _userManager { get; }
        public SellYourCar(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            SellCarViewModel model = new SellCarViewModel()
            {
                FuelTypes = await _db.fuelTypes.ToListAsync(),
                Years = await _db.years.ToListAsync(),
                Transmissions = await _db.transmissions.ToListAsync(),
                BodyStyles = await _db.bodyStyles.ToListAsync(),
                MotorSizes = await _db.motorSizes.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SellCarViewModel svm)
        {
            svm.Years = await _db.years.ToListAsync();
            svm.Transmissions = await _db.transmissions.ToListAsync();
            svm.BodyStyles = await _db.bodyStyles.ToListAsync();
            svm.FuelTypes = await _db.fuelTypes.ToListAsync();
            svm.MotorSizes = await _db.motorSizes.ToListAsync();
            if (svm.CarImages != null && svm.CarImages.Count < 12)
            {
                ModelState.AddModelError("CarImages", "Please add at least 12 images of your car.");
            }

            if (!ModelState.IsValid)
            {
                return View(svm);
            }
            //More validations to come here
            Car newToSell = new Car()
            {
                City = svm.City,
                Make = svm.Make,
                Model = svm.Model,
                YearId = svm.GetYearId,
                TransmissionId = svm.GetTransmissionId,
                BodyStyleId = svm.GetBodyStyleId,
                FuelTypeId = svm.GetFuelTypeId,
                MotorSizeId = svm.GetMotorSizeId,
                Mileage = Int32.Parse(svm.Mileage),
                Hp = svm.Hp,
                AuctionStartingPrice = Int32.Parse(svm.AuctionStartingPrice),
                SellerNote = svm.SellerNote,
                AppUser = await _userManager.FindByNameAsync(User.Identity.Name),
                EndTime = DateTime.Now.AddMinutes(5),
                Created = DateTime.Now,
                Status = true
            };

            await _db.cars.AddAsync(newToSell);
            await _db.SaveChangesAsync();

            if (svm.CarImages != null)
            {

                foreach (IFormFile img in svm.CarImages)
                {
                    if (!img.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("CarImages", "File is not image");
                        return View(svm);
                    }
                    if (img.Length / 1024 > 400)
                    {
                        ModelState.AddModelError("CarImages", "File is too large");
                        return View(svm);
                    }
                    string path = @"C:\Users\User\source\repos\MachineBazaar\MachineBazaar\wwwroot\assets\images\hero\";
                    string fileName = Guid.NewGuid().ToString() + img.FileName;
                    string finalPath = Path.Combine(path, fileName);

                    using (FileStream stream = new FileStream(finalPath, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }
                    CarImage carImages = new CarImage()
                    {
                        imagePath = fileName,
                        CarId = newToSell.Id
                    };
                    await _db.AddAsync(carImages);
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("index", "home");
        }
    }
}
