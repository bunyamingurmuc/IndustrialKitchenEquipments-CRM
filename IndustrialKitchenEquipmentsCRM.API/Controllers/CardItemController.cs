using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
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
    public class CardItemController : ControllerBase
    {
        private readonly ICardItemService _cardItemService;

        public CardItemController(ICardItemService cardItemService)
        {
            _cardItemService = cardItemService;
        }
        
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemGetAll()
        {
            var response = await _cardItemService.GetAllWithR();
            return this.ResponseStatusWithData(response);

        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemGet(int id)
        {
            var response = await _cardItemService.GetR(id);
            return this.ResponseStatusWithData(response);

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemCreate(CardItemCreateDto dto)
        {
            var response = await _cardItemService.CreateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemUpdate(CardItemUpdateDto dto)
        {
            var response = await _cardItemService.UpdateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemDelete(int id)
        {
            var response= await _cardItemService.RemoveAsync(id);
            return this.ResponseStatusWithData(response);

        }
    }
}
