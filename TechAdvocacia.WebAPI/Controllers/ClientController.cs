using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;

namespace TechAdvocacia.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]

public class ClientController : ControllerBase {
    private readonly IClientService _clientService;
    public List<ClientViewModel> Clients => _clientService.GetAll();
    public ClientController(IClientService service) => _clientService = service;

    [HttpGet("clients")]
    public IActionResult Get(){
        return Ok(Clients);
    }

    [HttpGet("clients/{id}")]
    public IActionResult GetById(int id){
        try{
            var client = _clientService.GetById(id);
            return Ok(client);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("client")]
    public IActionResult Post([FromBody] NewClientInputModel client){
        _clientService.Create(client);
        return CreatedAtAction(nameof(Get), client);
    }

    [HttpPut("client/{id}")]
    public IActionResult Put(int id, [FromBody] NewClientInputModel client)
    {
        if (_clientService.GetById(id) == null)
            return NoContent();
        _clientService.Update(id, client);
        return Ok(_clientService.GetById(id));
    }
    
    [HttpDelete("client/{id}")]
    public IActionResult Delete(int id)
    {
        if (_clientService.GetById(id) == null)
            return NoContent();
        _clientService.Delete(id);
        return Ok();
    }
}