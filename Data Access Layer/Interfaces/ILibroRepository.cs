using APIBiblioteca.Models;
using APIBiblioteca.Data_Access_Layer.Interfaces;

namespace API_Biblioteca.Data_Access_Layer.Interfaces
{
    public interface ILibroRepository : IGenericRepository<Libro>
    {
        public Task<Libro> ObtenerPorIdConRelacion(int id);
    }
}
