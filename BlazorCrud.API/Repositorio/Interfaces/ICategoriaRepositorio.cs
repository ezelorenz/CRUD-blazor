using BlazorCrud.API.Models;

namespace BlazorCrud.API.Repositorio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> ListaCategorias();
        Task<Categoria> GetCategoria(int idCategoria);
        Task<Categoria> AgregarCategoria(Categoria categoria);
        Task<bool> EditarCategoria(Categoria categoria);
        Task<bool> EliminarCategoria(Categoria categoria);
    }
}
