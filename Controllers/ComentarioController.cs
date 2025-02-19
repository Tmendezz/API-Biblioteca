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
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericRepository<Comentario> _repository;
        private readonly IMapper _mapper;
        public ComentarioController(IGenericRepository<Comentario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> UpdateAsync(ComentarioDTO comentarioDTO)
        {
            var comentario = _mapper.Map<Comentario>(comentarioDTO);
            var respuesta = await _repository.UpdateAsync(comentario);
            if (!respuesta)
                return BadRequest(respuesta);
            var dto = _mapper.Map<ComentarioDTO>(comentario);
            return Ok(dto);
        }
    }
}
