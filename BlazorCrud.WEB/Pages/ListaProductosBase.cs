using BlazorCrud.Models.Dtos;
using BlazorCrud.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorCrud.WEB.Pages
{
    public class ListaProductosBase : ComponentBase
    {
        [Inject]
        public IProductoService ProductoService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected List<ProductoDto> _products = new List<ProductoDto>();
        

        protected override async Task OnInitializedAsync()
        {
            _products = await ProductoService.ListaProductos();
        }

        protected async Task EliminarProducto(int idProducto)
        {
            await ProductoService.EliminarProducto(idProducto);
            NavigationManager.NavigateTo("/");
        }
    }
}
