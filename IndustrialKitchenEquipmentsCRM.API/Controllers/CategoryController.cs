using IndustrialKitchenEquipmentsCRM.API.Extension;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
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
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CategoryGetAll()
        {
            var response =await _categoryService.GetAllAsync();
            return this.ResponseStatusWithData(response);

        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CategoryGet(int id)
        {
            var response =await _categoryService.GetByIdAsync<CategoryListDto>(id);
            return this.ResponseStatusWithData(response);

        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CategoryCreate(CategoryCreateDto dto)
        {
            var response = await _categoryService.CreateAsync(dto);
            return this.ResponseStatusWithData(response);

        }

        [HttpPut]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CategoryUpdate(CategoryListDto dto)
        {
            var response = await _categoryService.UpdateAsync(dto);

            return this.ResponseStatusWithData(response);

        }

        [HttpDelete]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult> CategoryDelete(int id)
        {
           var response= await _categoryService.RemoveAsync(id);
           return this.ResponseStatusWithData(response);

        }

    }
}
