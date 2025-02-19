using APIBiblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _repository;
        private readonly IMapper _mapper;
        public AutorController(IGenericRepository<Autor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //Si no queremos retornar el ID, como ya vimos anteriormente, solo tenemos que cambiar 
        //al autorDTO por el AutorCreacionDTO. Así solo retornara el nombre y la fecha de nacimiento del autor, sin el id.
        //utilizando al AutorDTO, gracias a la funcion del automapper para rastrear la fecha en string, nos retornara la misma en ese formato.
        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAllAsync()
        {
            var autores = await _repository.GetAllAsync();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return Ok(autoresDTO);
        }

        [HttpGet("{id}", Name = "GetAutor")]
        public async Task<ActionResult<AutorDTO>> GetAsync(int id)
        {
            var autor = await _repository.GetAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            var autorDTO = _mapper.Map<AutorDTO>(autor);
            //Acá podemos retornar un 200 indicando que todo está bien
            //return Ok(autorDTO);
            //O podemos retornar un mensaje mas completo, que incluye la localizacion del objeto creado,
            //con el fin de darle mas informacion a nuestro cliente o a quien consuma la API.
            return new CreatedAtRouteResult("GetAutor", new { id = autor.Id }, autorDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AutorCreacionDTO autorCreacionDTO)
        {
            var autor = _mapper.Map<Autor>(autorCreacionDTO);

            var resultado = await _repository.Insert(autor);
            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<AutorCreacionDTO>(autor);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, AutorCreacionDTO autorCreacionDTO)
        {
            var autorDesdeRepo = await _repository.GetAsync(id);
            if (autorDesdeRepo == null)
                return NotFound();

            _mapper.Map(autorCreacionDTO, autorDesdeRepo);
            var resultado = await _repository.UpdateAsync(autorDesdeRepo);
            if (resultado)
                return NoContent();

            return BadRequest();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var autorDesdeRepo = await _repository.GetAsync(id);
            if(autorDesdeRepo == null)
                return NotFound();

            var resultado = await _repository.Delete(id);

            if (resultado)
                return NoContent();

            return BadRequest();


        }
    }
}
