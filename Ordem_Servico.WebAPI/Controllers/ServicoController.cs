using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;

namespace Ordem_Servico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class ServicoController : ControllerBase 
    {
        private readonly IServicoService _servicoService;
        public List<ServicoViewModel> Servicos => _servicoService.GetAll();
        public ServicoController(IServicoService service) => _servicoService = service;

        [HttpGet("servicos")]
        public IActionResult GetAll()
        {
            var servicos = _servicoService.GetAll();
            return Ok(servicos);
        }

        [HttpGet("servicos/{id}")]
        public IActionResult GetById(int id)
        {
            var servico = _servicoService.GetById(id);
            if (servico == null)
            {
                return NotFound();
            }
            return Ok(servico);
        }

        [HttpPost("servicos")]
        public IActionResult Create([FromBody] NewServicoInputModel servico)
        {
            var newServicoId = _servicoService.Create(servico);
            var createdServico = _servicoService.GetById(newServicoId);
            return CreatedAtAction(nameof(GetById), new { id = newServicoId }, createdServico);
        }

        [HttpPut("servicos/{id}")]
        public IActionResult Update(int id, [FromBody] NewServicoInputModel servico)
        {
            try
            {
                _servicoService.Update(id, servico);
                return Ok(_servicoService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("servicos/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servicoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

