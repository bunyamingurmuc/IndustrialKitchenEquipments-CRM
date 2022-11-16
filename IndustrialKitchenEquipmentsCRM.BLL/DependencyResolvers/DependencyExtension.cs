using System.Text;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.API.Extension.Token;
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
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
           
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = JwtTokenSettings.Issuer,
                    ValidAudience = JwtTokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddWkhtmltopdf("wkhtmltopdf");
          
            services.AddScoped<IUOW, UOW>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICardItemService, CardItemService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAppUserService, AppUserService>();



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

            services.AddSingleton<IValidator<AppUserCreateDto>, AppUserCDValidator>();
            services.AddSingleton<IValidator<AppUserListDto>, AppUserLDValidator>();


        }
    }

}
