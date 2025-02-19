using APIBiblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _repository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;
        public GeneroController(IGenericRepository<Genero> repository, IGeneroRepository generoRepository, IMapper mapper)
        {
            _repository = repository;
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GetAllAsync()
        {
            var generos = await _repository.GetAllAsync();
            var generosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            return Ok(generosDTO);
        }

        [HttpGet("conLibros")]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> ObtenerGeneroConLibros()
        {
            var generosConLibros = await _generoRepository.ObtenerConLibros();
            var generosConLibrosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generosConLibros);
            return Ok(generosConLibrosDTO);
        }


        [HttpGet("{id}", Name = "GetGenero")]
        public async Task<ActionResult<GeneroDTO>> GetAsync(int id)
        {
            var genero = await _repository.GetAsync(id);
            if (genero == null)
                return NotFound();
            var generoDTO = _mapper.Map<Libro>(genero);
            return Ok(generoDTO);
        }

        [HttpPost]
        //Si solo queremos devolver el nombre del genero sin el ID y su lista de libros, solo tenemos que cambiar el mapeo
        //de GeneroDTO a GeneroCreacionDTO y aplicar un ReverseMap() en el AutoMapperProfile.
        public async Task<ActionResult> Create([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            await _repository.Insert(genero);
            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return Ok(generoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var generoDesdeRepo = await _repository.GetAsync(id);
            if (generoDesdeRepo == null)
                return NotFound();

            _mapper.Map(generoCreacionDTO, generoDesdeRepo);
            var resultado = await _repository.UpdateAsync(generoDesdeRepo);
            if (resultado)
                return NoContent();

            return BadRequest();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var generoDesdeRepo = await _repository.GetAsync(id);
            if (generoDesdeRepo == null)
                return NotFound();

            var resultado = await _repository.Delete(id);

            if (resultado)
                return NoContent();

            return BadRequest();


        }

    }
}
