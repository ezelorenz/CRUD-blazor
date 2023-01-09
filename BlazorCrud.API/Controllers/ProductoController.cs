using AutoMapper;
using BlazorCrud.API.Dtos;
using BlazorCrud.API.Models;
using BlazorCrud.API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepositorio _repoProducto;
        private readonly IMapper _mapper;
        public ProductoController(IProductoRepositorio repoProducto, IMapper mapper)
        {
            _repoProducto = repoProducto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetItems()
        {
            try
            {
                var products = await _repoProducto.ListaProductos();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = _mapper.Map<IEnumerable<ProductoDto>>(products);
                    return Ok(productDtos);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
