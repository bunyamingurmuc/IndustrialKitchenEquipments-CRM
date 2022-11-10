using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.CustomDescriber;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.BLL.Services;
using IndustrialKitchenEquipmentsCRM.BLL.ValidationRules;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IndustrialKitchenEquipmentsContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            services.AddIdentity<AppUser, AppRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 1;
            }).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<IndustrialKitchenEquipmentsContext>();

            services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                o.Cookie.Name = "FormCookie";
                o.ExpireTimeSpan = TimeSpan.FromDays(1);
                o.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/account/accessdeied");
                o.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;


            });
            services.AddWkhtmltopdf("wkhtmltopdf");
          
            services.AddScoped<IUOW, UOW>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICardItemService, CardItemService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICustomerService, CustomerService>();



            services.AddSingleton<IValidator<StockCreateDto>, StockCDValidator>();
            services.AddSingleton<IValidator<StockListDto>, StockLDValidator>();

            services.AddSingleton<IValidator<CategoryListDto>, CategoryLDValidator>();
            services.AddSingleton<IValidator<CategoryCreateDto>, CategoryCDValidator>();

            services.AddSingleton<IValidator<CardItemCreateDto>, CardItemCDValidator>();
            services.AddSingleton<IValidator<CardItemListDto>, CardItemLDValidator>();

            services.AddSingleton<IValidator<CardListDto>, CardLDValidator>();
            services.AddSingleton<IValidator<CardCreateDto>, CardCDValidator>();

            services.AddSingleton<IValidator<ImageListDto>, ImageLDValidator>();
            services.AddSingleton<IValidator<ImageCreateDto>, ImageCDValidator>();

            services.AddSingleton<IValidator<CustomerListDto>, CustomerLDValidator>();
            services.AddSingleton<IValidator<CustomerCreateDto>, CustomerCDValidator>();


        }
    }

}
