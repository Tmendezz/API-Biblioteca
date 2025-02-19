using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using System.Runtime.InteropServices;
namespace APIBiblioteca.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Usamos el ReverseMap para evitar tener que agregar una linea de codigo que haga el mapeo inverso de 
            //Autor a AutorCreacionDTO.
            CreateMap<AutorCreacionDTO, Autor>()
                .ForMember(d => d.FechaNacimiento,
                    opt => opt.MapFrom(o => DateTime.Parse(o.FechaNacimiento))).ReverseMap();

            CreateMap<Autor, AutorDTO>()
                .ForMember(d => d.FechaNacimiento,
                opt => opt.MapFrom(o => o.FechaNacimiento.ToString("dd/MM/yyyy")));

            CreateMap<Genero, GeneroDTO>();
            CreateMap<GeneroCreacionDTO, Genero>().ReverseMap();

            CreateMap<Libro, LibroDTO>()
                .ForMember(d => d.NombreAutor, o => o.MapFrom(src => src.Autor.Nombre))
                .ForMember(d => d.NombreGenero, o => o.MapFrom(src => src.Genero.Nombre))
                .ForMember(d => d.FechaLanzamiento, opt => opt.MapFrom(o => o.FechaLanzamiento.ToString("dd/MM/yyyy")));



            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Autor, o => o.Ignore())
                .ForMember(d => d.Genero, o => o.Ignore())
                .ForMember(d => d.FechaLanzamiento,
                    opt => opt.MapFrom(o => DateTime.Parse(o.FechaLanzamiento)));

            CreateMap<Comentario, ComentarioDTO>().ReverseMap();
            CreateMap<ListaComentariosDTO, Comentario>().ReverseMap();



        }
    }
}
