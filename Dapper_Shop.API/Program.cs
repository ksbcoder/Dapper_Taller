using AutoMapper.Data;
using Dapper_Shop.API.AutoMapper;
using Dapper_Shop.Domain.UseCases.Gateway;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Dapper_Shop.Domain.UseCases.UseCases;
using Dapper_Shop.Infrastructure.Gateway;
using Dapper_Shop.Infrastructure.SqlAdapter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(Configuration));

builder.Services.AddScoped<IShopUseCase, ShopUseCase>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();

builder.Services.AddScoped<ICustomerUseCase, CustomerUseCase>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IVehicleUseCase, VehicleUseCase>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("urlConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
