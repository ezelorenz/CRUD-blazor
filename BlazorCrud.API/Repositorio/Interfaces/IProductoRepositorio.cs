using BlazorCrud.API.Models;

namespace BlazorCrud.API.Repositorio.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> ListaProductos();
        Task<Producto> GetProducto(int idProducto);
        Task<Producto> AgregarProducto(Producto producto);
        Task<bool> EditarProducto(Producto producto);
        Task<bool> EliminarProducto(Producto producto);
    }
}
