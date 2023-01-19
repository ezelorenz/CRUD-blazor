using AutoMapper;
using BlazorCrud.API.Dtos;
using BlazorCrud.API.Models;

namespace BlazorCrud.API.Extensiones
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(p => p.NombreCategoria,
                            opt => opt.MapFrom(o => o.IdCategoriaNavigation.Descripcion));

            CreateMap<ProductoDto, Producto>()
                .ForMember(p => p.IdCategoriaNavigation,
                            opt => opt.Ignore());

            CreateMap<Producto, ProductoCreacionDto>()
                .ForMember(p => p.NombreCategoria,
                            opt => opt.MapFrom(o => o.IdCategoriaNavigation.Descripcion));

            CreateMap<ProductoCreacionDto, Producto>()
                .ForMember(p => p.IdCategoriaNavigation,
                            opt => opt.Ignore());

            CreateMap<Categoria, CategoriaDto>().ReverseMap();
        }
    }
}
