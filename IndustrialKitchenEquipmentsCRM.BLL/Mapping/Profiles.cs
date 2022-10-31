using AutoMapper;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Category;
using IndustrialKitchenEquipmentsCRM.Entities.Customer;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;

namespace IndustrialKitchenEquipmentsCRM.BLL.Mapping
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<Stock, StockListDto>().ReverseMap();
            CreateMap<Stock, StockCreateDto>().ReverseMap();

            CreateMap<CardCreateDto,Card>().ReverseMap();
            CreateMap<CardListDto,Card>().ReverseMap();

            CreateMap<CardItemListDto,CardItem>().ReverseMap();
            CreateMap<CardItemCreateDto,CardItem>().ReverseMap();

            CreateMap<CategoryListDto,Category>().ReverseMap();
            CreateMap<CategoryCreateDto,Category>().ReverseMap();

            CreateMap<ImageCreateDto,Image>().ReverseMap();
            CreateMap<ImageListDto,Image>().ReverseMap();

             CreateMap<CustomerListDto,Customer>().ReverseMap();
             CreateMap<CustomerCreateDto,Customer>().ReverseMap();
      
            

            CreateMap<AppUserListDto, AppUser>();


        }
    }
}
