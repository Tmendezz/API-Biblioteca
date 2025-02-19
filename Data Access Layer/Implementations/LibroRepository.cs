using API_Biblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.Data_Access_Layer.DataContext;
using APIBiblioteca.Data_Access_Layer.Implementations;
using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca.Data_Access_Layer.Implementations
{
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        private readonly ApplicationDbContext _context;
        public LibroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Libro> ObtenerPorIdConRelacion(int id)
        {
            var query = await _context.Libros
                                        .Include(a => a.Autor)
                                        .Include(g => g.Genero)
                                        .Include(c => c.Comentarios)
                                        .FirstOrDefaultAsync(l => l.Id == id);
            return query;
        }
    }
}
