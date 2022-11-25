using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CustomerGetAll()
        {
            var response = await _customerService.GetAllWithR();
            return this.ResponseStatusWithData(response);

        }



        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CustomerGetById(int id)
        {
            var response = await _customerService.GetR(id);
            return this.ResponseStatusWithData(response);

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CustomerCreate(CustomerCreateDto dto)
        {
            var response = await _customerService.CreateAsync(dto);

            return this.ResponseStatusWithData(response);

        }
        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CustomerUpdate(CustomerListDto dto)
        {
            var response = await _customerService.UpdateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CustomerDelete(int id)
        {
            var response = await _customerService.RemoveAsync(id);
            return this.ResponseStatusWithData(response);

        }
    }
}
