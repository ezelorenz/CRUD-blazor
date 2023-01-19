using BlazorCrud.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorCrud.WEB.Pages
{
	public class AgregarProductoBase : ComponentBase
    {
        [Inject]
        public IProductoService ProductoService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
    }
}
