using BlazorCrud.API.Context;
using BlazorCrud.API.Models;
using BlazorCrud.API.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.API.Repositorio.Implementaciones
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly CrudblazorContext db;
        public ProductoRepositorio(CrudblazorContext dataBase)
        {
            db = dataBase;
        }
        public Task<Producto> GetProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> ListaProductos()
        {
            return await db.Productos
                            .Include(c => c.IdCategoriaNavigation).ToListAsync();
        }
        public Task<Producto> AgregarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

    }
}
