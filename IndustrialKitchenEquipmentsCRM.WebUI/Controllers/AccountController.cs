using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(CLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Parola yanlış");
                return View(dto);

            }
            return View(dto);
        }

        public async Task<IActionResult> CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CCreateAccountDto dto)
        {
            if (!(dto.Email.Contains("@") && dto.Email.Contains(".com")))
            {

                ModelState.AddModelError("", "Geçerli bir mail adresi giriniz");
                return View(dto);
            }
            AppUser appUser = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                SurName = dto.Surname,
                UserName = dto.Email,
            };

            var identityResult = await _userManager.CreateAsync(appUser, dto.Password);
            if (identityResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(appUser.UserName);
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Member"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Admin"
                    });

                }
                await _userManager.AddToRoleAsync(user, "Member");
                return RedirectToAction("LogIn");
            }
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(dto);
        }
       
        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }



}
