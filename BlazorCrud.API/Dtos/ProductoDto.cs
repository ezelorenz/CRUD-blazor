

namespace BlazorCrud.API.Dtos
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }

        public string? Marca { get; set; }

        public string? Descripcion { get; set; }

        public string NombreCategoria { get; set; }

        public decimal? Precio { get; set; }
    }
}
