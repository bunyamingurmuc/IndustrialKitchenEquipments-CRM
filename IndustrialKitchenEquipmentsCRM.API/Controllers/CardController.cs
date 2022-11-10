using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IGeneratePdf _generatePdf;


        public CardController(ICardService cardService, IGeneratePdf generatePdf)
        {
            _cardService = cardService;
            _generatePdf = generatePdf;
        }
        [Authorize]
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardGetAll()
        {
            var response = await _cardService.GetAllAsync();
            return this.ResponseStatusWithData(response);
        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardGetById(int id)
        {
            var response = await _cardService.GetByIdAsync<CardListDto>(id);
            return this.ResponseStatusWithData(response);
           

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardCreate(CardCreateDto dto)
        {
            var response = await _cardService.CreateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardUpdate(CardListDto dto)
        {
            var response = await _cardService.UpdateAsync(dto);
            return this.ResponseStatusWithData(response);

        }
        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardDelete(int id)
        {
            var response = await _cardService.RemoveAsync(id);
            return this.ResponseStatusWithData(response);

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> CreatePdf()
        {
       
            return await _generatePdf.GetPdf("Denemee");
        }

    }
}
