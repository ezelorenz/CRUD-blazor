using BlazorCrud.API.Context;
using BlazorCrud.API.Models;
using BlazorCrud.API.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.API.Repositorio.Implementaciones
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly CrudblazorContext db;
        public CategoriaRepositorio(CrudblazorContext dataBase)
        {
            db = dataBase;
        }
        public Task<Categoria> AgregarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Categoria>> ListaCategorias()
        {
            return await db.Categoria.ToListAsync();
        }
    }
}
