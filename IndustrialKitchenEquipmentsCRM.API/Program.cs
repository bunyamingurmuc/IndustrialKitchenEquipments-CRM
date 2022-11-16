using System.Text;
using AutoMapper;
using IndustrialKitchenEquipmentsCRM.API.Extension.Token;
using IndustrialKitchenEquipmentsCRM.BLL.DependencyResolvers;
using IndustrialKitchenEquipmentsCRM.BLL.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCors",b =>
    {
        b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencies(builder.Configuration);
var profiles = ProfileHelper.GetProfiles();
var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GlobalCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
