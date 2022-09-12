using MachineBazaar.DAL;
using MachineBazaar.Models;
using MachineBazaar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBazaar.Controllers
{
    public class Account : Controller
    {
        private UserManager<AppUser> _userManager { get; }
        private SignInManager<AppUser> _signInManager { get; }
        private AppDbContext _db { get; }
        public Account(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> MyListings()
        {
            AppUser? user = await _db.Users.
                Include(element => element.Cars).
                ThenInclude(element => element.CarBids).
                Include(element => element.Cars).
                ThenInclude(element => element.Year).
                Include(element => element.Cars).
                ThenInclude(element => element.Images).
                Include(element => element.Cars).
                ThenInclude(element => element.BodyStyle).
                Include(element => element.Cars).
                ThenInclude(element => element.FuelType).
                Include(element => element.Cars).
                ThenInclude(element => element.Transmission).
                FirstOrDefaultAsync(item => item.UserName == User.Identity.Name);
            return View(user);
        }
       
        public async Task<IActionResult> MyProfile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(user);
        }
        public async Task<IActionResult> EditProfile()
        {
            EditViewModel evm = new EditViewModel()
            {
                User = await _userManager.FindByNameAsync(User.Identity.Name)
            };
            return View(evm);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditViewModel userEdited)
        {
            userEdited.User = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View(userEdited);
            }
            AppUser user = await _userManager.FindByNameAsync(userEdited.User.UserName);
            user.Email = userEdited.Email;
            user.UserName = userEdited.UserName;
            user.PhoneNumber = userEdited.PhoneNumber.ToString();
            if (userEdited.Img != null)
            {
                if (!userEdited.Img.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Img", "File is not image");
                    return View(userEdited);
                }
                if (userEdited.Img.Length / 1024 > 400)
                {
                    ModelState.AddModelError("Img", "File is too large");
                    return View(userEdited);
                }
                string path = @"C:\Users\User\source\repos\MachineBazaar\MachineBazaar\wwwroot\assets\images\ProfilePhotos\";
                string fileName = Guid.NewGuid().ToString() + userEdited.Img.FileName;
                string finalPath = Path.Combine(path, fileName);

                if (System.IO.File.Exists(Path.Combine(path, user.ProfilePicture)) && user.ProfilePicture != "defaultprofile.png")
                {
                    System.IO.File.Delete(Path.Combine(path, user.ProfilePicture));
                }

                using (FileStream stream = new FileStream(finalPath, FileMode.Create))
                {
                    await userEdited.Img.CopyToAsync(stream);
                }
                user.ProfilePicture = fileName;
            }

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userEdited);
            }

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("myprofile", "account");
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel lvm)
        {
            if (!ModelState.IsValid)
            {
                return View(lvm);
            }
            AppUser user = await _userManager.FindByNameAsync(lvm.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
                return View(lvm);
            }
            Microsoft.AspNetCore.Identity.SignInResult result  = await _signInManager.CheckPasswordSignInAsync(user, lvm.Password, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
                return View(lvm);
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("index", "home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                UserName = rvm.UserName,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber.ToString(),
                ProfilePicture = "defaultprofile.png",
                JoinDate = DateTime.Now.ToString("MMMM dd")
            };
            IdentityResult result = await _userManager.CreateAsync(user, rvm.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(rvm);
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
