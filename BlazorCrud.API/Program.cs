using BlazorCrud.API.Context;
using BlazorCrud.API.Repositorio.Implementaciones;
using BlazorCrud.API.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CrudblazorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
        opt.AddPolicy(name: misReglasCors, builder =>
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();


builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(misReglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
