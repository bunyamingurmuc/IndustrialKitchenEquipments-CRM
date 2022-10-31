using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var response = await _cardItemService.GetAllAsync();
            return this.ResponseStatusWithData(response);

        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardItemGet(int id)
        {
            var response = await _cardItemService.GetByIdAsync<CardItem>(id);
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
        public async Task<ActionResult> CardItemUpdate(CardItemListDto dto)
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
