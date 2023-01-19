
using BlazorCrud.Models.Dtos;
using BlazorCrud.WEB.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorCrud.WEB.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;
        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<ProductoDto>> ListaProductos()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/producto");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductoDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductoDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<ProductoCreacionDto> CreacionProducto(ProductoCreacionDto productoCreacion)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoCreacionDto> EditarProducto(int idProducto, ProductoCreacionDto productoCreacion)
        {
            throw new NotImplementedException();
        }

        public async Task EliminarProducto(int idProducto)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/producto/{idProducto}");
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<ProductoDto> GetById(int idProducto)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/producto/{idProducto}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ProductoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
