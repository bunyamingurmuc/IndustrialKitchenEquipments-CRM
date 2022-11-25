using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public static IWebHostEnvironment _environment;

        public ImageController(IImageService imageService, IWebHostEnvironment environment)
        {
            _imageService = imageService;
            _environment = environment;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageGetAll()
        {
            var images = await _imageService.GetAllWithR();
            return this.ResponseStatusWithData(images);
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageGetById(int id)
        {
            var response = await _imageService.GetR(id);
            return this.ResponseStatusWithData(response);

        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageCreate(ImageCreateDto dto)
        {
            var response = await _imageService.CreateAsync(dto);
            return this.ResponseStatusWithData(response);


        }

        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageUpdate(ImageListDto dto)
        {
            var response = await _imageService.UpdateAsync(dto);
            return this.ResponseStatusWithData(response);

        }

        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageDelete(int id)
        {
            var response = await _imageService.RemoveAsync(id);
            return this.ResponseStatusWithData(response);

        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageUpload([FromForm] CImageUploadDto dto, int stokId)
        {
            if (dto.File.Length > 0)
            {
                string path = _environment.WebRootPath + "\\Upload\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 4000); 
                var filepath = _environment.WebRootPath + "\\Upload\\"+"img" + randomNumber+".png";
                FileStream fileStream =
                            System.IO.File.Create(filepath);
                var response = _imageService.CreateImage(fileStream, dto.File);
                if (response.ResponseType == ResponseType.Success)

                {
                    var response1 = await _imageService.CreateAsync(new ImageCreateDto()
                    {
                        StockId = stokId,
                        Url = filepath,

                    });
                    return this.ResponseStatusWithData(response);
                }
                else
                {
                    return BadRequest("Bir hata oluştu");
                }
            }

            return BadRequest();
        }

    }
}
