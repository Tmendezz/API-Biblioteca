using APIBiblioteca.Models;

namespace APIBiblioteca.DTO
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public HashSet<LibroDTO> Libros { get; set; } = new HashSet<LibroDTO>();
    }
}
