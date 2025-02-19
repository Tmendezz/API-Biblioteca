using APIBiblioteca.Data_Access_Layer.DataContext;
using APIBiblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Data_Access_Layer.Implementations
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext _context;
        public GeneroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> ObtenerConLibros()
        {
            return await _context.Generos.Include(l => l.Libros)
                                                    .ThenInclude(l => l.Autor)
                                                    .ToListAsync();
        }
    }
}
