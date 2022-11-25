using System.Drawing;
using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IImageService _imageService;
        private readonly IGeneratePdf _generatePdf;
        public static IWebHostEnvironment _environment;

        public CardController(ICardService cardService, IGeneratePdf generatePdf, IWebHostEnvironment environment, IImageService imageService)
        {
            _cardService = cardService;
            _generatePdf = generatePdf;
            _environment = environment;
            _imageService = imageService;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardGetAll()
        {
            var response = await _cardService.GetAllWithR();
            return this.ResponseStatusWithData(response);
        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardGetById(int id)
        {
            var response = await _cardService.GetR(id);
            return this.ResponseStatusWithData(response);
           

        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CardCreate(CardCreateDto dto)
        {
            var response = await _cardService.CreateR(dto);
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
            var myConvertOptions = new MyConvertOptions
            {
                FooterCenter = "\" Sayfa [page] / [topage] \"",
                HeaderHtml = "Views/dene.html",
                EnableLocalAccess = true
            };
            var path = _environment.WebRootPath + "\\Upload\\" + "1.jpg";
            var dto = new PdfReportDto
            {
                Imagesrc = _imageService.ConvertToBase64(path)
            };
            _generatePdf.SetConvertOptions(myConvertOptions);
            var result= await _generatePdf.GetPdf("Denemee", dto);
            return result;
        }
    }
}
