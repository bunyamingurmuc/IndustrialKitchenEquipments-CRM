using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.API.Extension.Token;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> CreateAccount(CCreateAccountDto dto)
        {
            var response = await _appUserService.CreateUser(dto);
           return this.ResponseStatusWithData(response);
        }


        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> LogIn(CLoginDto dto)
        {
            var response = await _appUserService.GetAllAsync();
            var appusers = response.Data;
            var user = appusers.FirstOrDefault(i => i.Email == dto.Email && i.Password == dto.Password);
            if (user == null)
            {
                return NotFound("Kullanıcı adı veya parola yanlış"); 
            }
            else
            {
                var token = JwtTokenGenerator.GenerateToken(dto);
                return Created("", token);
            }
        }

        //[HttpGet]
        //[Route("/[controller]/[action]")]

        //public async Task<ActionResult> LogOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok();
        //}

    }
}
