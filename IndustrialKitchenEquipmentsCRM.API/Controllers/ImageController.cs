using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var images = await _imageService.GetAllAsync();
            return this.ResponseStatusWithData(images);
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> ImageGetById(int id)
        {
            var response = await _imageService.GetByIdAsync<ImageListDto>(id);
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
        public ActionResult ImageUpload([FromForm] CImageUploadDto dto)
        {
            if (dto.File.Length > 0)
            {
                string path = _environment.WebRootPath + "\\Upload\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }

                FileStream fileStream =
                    System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + dto.File.FileName);
                var response = _imageService.CreateImage(fileStream, dto.File);
                return this.ResponseStatusWithData(response);
            }

            return BadRequest();
        }

    }
}
