using AutoMapper;
using ProductAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<Producto, ProductoDto>()
            .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria.Nombre));
        CreateMap<ProductoCreateDto, Producto>();
    }
}