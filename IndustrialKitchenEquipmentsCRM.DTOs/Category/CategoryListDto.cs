using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Category
{
    public class CategoryListDto:IListDto
    {
        public CategoryListDto()
        {
            Stocks = new List<StockListDto>();
        }
        public string CategoryName { get; set; }
        public List<StockListDto> Stocks { get; set; }


    }
}
