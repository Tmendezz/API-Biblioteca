using APIBiblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.Models;

namespace APIBiblioteca.Data_Access_Layer.Interfaces
{
    public interface IGeneroRepository : IGenericRepository<Genero>
    {
        public Task<IEnumerable<Genero>> ObtenerConLibros();
    }
}
