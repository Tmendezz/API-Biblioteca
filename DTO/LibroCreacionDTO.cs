namespace APIBiblioteca.DTO
{
    public class LibroCreacionDTO
    {
        public string Titulo { get; set; }
        public bool ParaPrestar { get; set; }
        public string FechaLanzamiento { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}
