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

        [HttpGet("{id:int}", Name = "GetProducto")]

        public async Task<ActionResult<ProductoDto>>GetItem(int idProducto)
        {
            try
            {
                var producto = await _repoProducto.GetProducto(idProducto);
                if (producto == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productoDto = _mapper.Map<ProductoDto>(producto);
                    return Ok(productoDto);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CrearItem([FromBody] ProductoCreacionDto productoCreacionDto)
        {
            var producto = _mapper.Map<Producto>(productoCreacionDto);
            await _repoProducto.AgregarProducto(producto);

            //validar el que la categoria sea la correcta


            var dto = _mapper.Map<ProductoDto>(producto);
            return new CreatedAtRouteResult("GetProducto", new { id = producto.IdProducto }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarProducto(int idProducto, ProductoCreacionDto productoCreacionDto)
        {
            var producto = await _repoProducto.GetProducto(idProducto);
            if(producto == null)
            {
                BadRequest("No existe el producto a actualizar");
            }
            _mapper.Map(productoCreacionDto, producto);

            var respuesta = await _repoProducto.EditarProducto(producto);
            if (!respuesta)
            {
                throw new Exception("No se pudo actualizar el producto");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult>EliminarProducto(int idProducto)
        {
            var producto = await _repoProducto.GetProducto(idProducto);
            if(producto == null)
                BadRequest("No existe el producto que desea eliminar");
            
            var respuesta = await _repoProducto.EliminarProducto(producto);
            if (!respuesta)
                throw new Exception("No se pudo eliminar el producto");

            return Ok();
        }
    }
}
