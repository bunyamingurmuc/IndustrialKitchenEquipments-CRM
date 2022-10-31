using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
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
    }
}
