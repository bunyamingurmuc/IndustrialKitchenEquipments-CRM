using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> CreateAccount(CCreateAccountDto dto)
        {

            AppUser appUser = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                SurName = dto.Surname,
                UserName = dto.Email,
                Adress=dto.Adress,
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
                return Ok(appUser);
            }
            else
            {
                return BadRequest(""); 
            }
        }


        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> LogIn(CLoginDto dto)
        {


            var signInResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }


        }



    }
}
