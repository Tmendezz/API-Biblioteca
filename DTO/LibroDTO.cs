using APIBiblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Titulo { get; set; }
        public bool ParaPrestar { get; set; }
        public string FechaLanzamiento { get; set; }
        public string NombreAutor { get; set; }
        public string NombreGenero { get; set; }
        public HashSet<ListaComentariosDTO> Comentarios { get; set; } = new HashSet<ListaComentariosDTO>();
    }
}
