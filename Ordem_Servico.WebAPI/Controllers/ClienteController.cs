using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordem_Servico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class ClienteController : ControllerBase
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        [HttpGet("clientes")]
        public IActionResult Get()
        {
            return Ok(_clientes);
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost("cliente")]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }

            _clientes.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteID }, cliente);
        }

        [HttpPut("cliente/{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            var existingCliente = _clientes.FirstOrDefault(c => c.ClienteID == id);
            if (existingCliente == null)
            {
                return NotFound();
            }

            existingCliente.Nome = cliente.Nome;

            return Ok(existingCliente);
        }

        [HttpDelete("cliente/{id}")]
        public IActionResult Delete(int id)
        {
            var existingCliente = _clientes.FirstOrDefault(c => c.ClienteID == id);
            if (existingCliente == null)
            {
                return NotFound();
            }

            _clientes.Remove(existingCliente);

            return NoContent();
        }
    }
}
