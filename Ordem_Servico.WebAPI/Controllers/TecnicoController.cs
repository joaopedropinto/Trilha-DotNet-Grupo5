using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application;

namespace Ordem_Servico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class TecnicoController : ControllerBase 
    {
        private readonly ITecnicoService _tecnicoService;
        public List<TecnicoViewModel> Tecnicos => _tecnicoService.GetAll();
        public TecnicoController(ITecnicoService service) => _tecnicoService = service;


        [HttpGet("tecnicos")]
        public IActionResult GetAll()
        {
            return Ok(_tecnicoService.GetAll());
        }

        [HttpGet("tecnicos/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var tecnico = _tecnicoService.GetById(id);
                return Ok(tecnico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("tecnicos")]
        public IActionResult Create([FromBody] NewTecnicoInputModel tecnico)
        {
            var newTecnicoId = _tecnicoService.Create(tecnico);
            var createdTecnico = _tecnicoService.GetById(newTecnicoId);
            return CreatedAtAction(nameof(GetById), new { id = newTecnicoId }, createdTecnico);
        }

        [HttpPut("tecnicos/{id}")]
        public IActionResult Update(int id, [FromBody] NewTecnicoInputModel tecnico)
        {
            try
            {
                _tecnicoService.Update(id, tecnico);
                return Ok(_tecnicoService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("tecnicos/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tecnicoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}