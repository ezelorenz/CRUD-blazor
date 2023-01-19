using AutoMapper;
using BlazorCrud.API.Dtos;
using BlazorCrud.API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _repoCategoria;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepositorio repoCategoria, IMapper mapper)
        {
            _repoCategoria = repoCategoria;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetItems()
        {
            try
            {
                var categorias = await _repoCategoria.ListaCategorias();

                if (categorias == null)
                {
                    return NotFound();
                }
                else
                {
                    var categoriasDtos = _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
                    return Ok(categoriasDtos);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
