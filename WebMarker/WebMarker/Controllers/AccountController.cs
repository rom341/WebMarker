using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMarker.Data;
using WebMarker.Models;
using WebMarker.ViewModels;

namespace WebMarker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View(new LoginViewModel());//return clear form
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);
            if (user != null)
            {
                //user exists
                bool isPasswordOk = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (isPasswordOk)
                {
                    //password is correct
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //password is incorrect
                ModelState.AddModelError("", "Invalid password");
                return View(loginViewModel);
            }
            //user is not found
            ModelState.AddModelError("", "User is not found");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());//return clear form
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if(user != null)
            {
                ModelState.AddModelError("", "Account with this email is already exists");
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };

            var newUserResponce = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if (!newUserResponce.Succeeded)
            {
                foreach(var e in newUserResponce.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
                return View(registerViewModel);
            }

            await _userManager.AddToRoleAsync(newUser, AppUserRoles.User);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
