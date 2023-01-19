using BlazorCrud.Models.Dtos;
using BlazorCrud.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace BlazorCrud.WEB.Pages
{
	public class EditarProductoBase : ComponentBase
	{
		[Inject] IProductoService ProductoService { get; set; }
		[Parameter] public string Id { get; set; }
        public ProductoDto Producto { get; set; } = new ProductoDto();

        protected override async Task OnInitializedAsync()
		{
			Producto = await ProductoService.GetById(int.Parse(Id));
		}

	}
}
