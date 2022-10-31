using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }


        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> StockGetAll()
        {
           var response=await _stockService.GetAllStocksWithR();
            return this.ResponseStatusWithData(response);
            
        }

       

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> StockGetById(int id)
        {
            var response = await _stockService.GetByIdAsync<StockListDto>(id);
            return this.ResponseStatusWithData(response);

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> StockCreate(StockCreateDto dto)
        {
           var response= await _stockService.CreateAsync(dto);
           
           return this.ResponseStatusWithData(response);

        }
        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> StockUpdate(StockListDto dto)
        {
            var response = await _stockService.UpdateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> StockDelete(int id)
        {
            var response = await _stockService.RemoveAsync(id);
            return this.ResponseStatusWithData(response);

        }

    }
}
