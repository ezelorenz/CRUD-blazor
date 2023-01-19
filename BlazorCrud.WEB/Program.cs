using BlazorCrud.WEB;
using BlazorCrud.WEB.Services;
using BlazorCrud.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7052/") });

builder.Services.AddScoped<IProductoService, ProductoService>();

await builder.Build().RunAsync();
