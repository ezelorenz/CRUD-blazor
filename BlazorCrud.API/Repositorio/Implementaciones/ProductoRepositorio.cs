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
        public async Task<Producto> GetProducto(int idProducto)
        {
            return await db.Productos
                            .Include(c => c.IdCategoriaNavigation).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
        }

        public async Task<IEnumerable<Producto>> ListaProductos()
        {
            return await db.Productos
                            .Include(c => c.IdCategoriaNavigation).ToListAsync();
        }
        public async Task<Producto> AgregarProducto(Producto producto)
        {
            try
            {
                db.Productos.Add(producto);
                await db.SaveChangesAsync();
                return producto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarProducto(Producto producto)
        {
            try
            {
                db.Productos.Update(producto);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EliminarProducto(Producto producto)
        {
            try
            {
                db.Productos.Remove(producto);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
