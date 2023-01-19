using BlazorCrud.Models.Dtos;

namespace BlazorCrud.WEB.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ListaProductos();
        Task<ProductoDto>GetById(int idProducto);
        Task<ProductoCreacionDto>CreacionProducto(ProductoCreacionDto productoCreacion);
        Task<ProductoCreacionDto>EditarProducto(int idProducto, ProductoCreacionDto productoCreacion);
        Task EliminarProducto(int idProducto);
    }
}
