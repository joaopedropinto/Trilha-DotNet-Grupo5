using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ResTIConnect.WebAPI.Controllers;
[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class SistemaController : ControllerBase
{
    private readonly ISistemaService _sistemaService;
    public List<SistemaViewModel> Sistemas => _sistemaService.GetAll();
    public SistemaController(ISistemaService service) => _sistemaService = service;

    [HttpGet("sistemas")]
    public IActionResult GetAll()
    {
        try
        {
            var sistemas = _sistemaService.GetAll();
            return Ok(sistemas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sistemas/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var sistema = _sistemaService.GetById(id);
            return Ok(sistema);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sistema/user/{id}")]
    public IActionResult GetSistemasByUserId(int id)
    {
        try
        {
            var sistemas = _sistemaService.GetSistemasByUserId(id);
            return Ok(sistemas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sistema/evento/{type}/from/{date}")]
    public IActionResult GetSystemsByEventFromDate(string type, DateTimeOffset date)
    {
        try
        {
            var systems = _sistemaService.GetSystemsByEventFromDate(type, date);
            return Ok(systems);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao buscar sistemas por evento e data: {ex.Message}");
        }
    }


    [HttpPost("sistema")]
    public IActionResult Create([FromBody] NewSistemaInputModel sistema)
    {
        try
        {
            var id = _sistemaService.Create(sistema);
            return CreatedAtAction(nameof(GetById), new { id = id }, sistema);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("sistema/{id}")]
    public IActionResult Update(int id, [FromBody] NewSistemaInputModel sistema)
    {
        try
        {
            _sistemaService.Update(id, sistema);
            return Ok(_sistemaService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("sistema/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _sistemaService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

