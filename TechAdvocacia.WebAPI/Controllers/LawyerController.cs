using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;

namespace TechAdvocacia.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LawyerController : ControllerBase
{
   private readonly ILawyerService _lawyerservice;
   public List<LawyerViewModel> Lawyers => _lawyerservice.GetAll().ToList();
   public LawyerController(ILawyerService service) => _lawyerservice = service;

   [HttpGet("lawyers")]
   public IActionResult Get()
   {
      return Ok(Lawyers);
   }

   [HttpGet("lawyer/{id}")]
   public IActionResult GetById(int id)
   {
      var lawyer = _lawyerservice.GetById(id);
      if (lawyer is null)
         return NoContent();
      return Ok(lawyer);
   }

   [HttpPost("lawyer")]
   public IActionResult Post([FromBody] NewLawyerInputModel lawyer)
   {
      _lawyerservice.Create(lawyer);
      return CreatedAtAction(nameof(Get), lawyer);
 
   }

   [HttpPost("lawyer/{id}/legalCase")]
   public IActionResult Post(int id, [FromBody] NewLegalCaseInputModel legalCase)
   {
      _lawyerservice.CreateLegalCase(id,legalCase);
      return CreatedAtAction(nameof(Get), legalCase);
 
   }

   [HttpPut("lawyer/{id}")]
   public IActionResult Put(int id, [FromBody] NewLawyerInputModel lawyer)
   {
      if (_lawyerservice.GetById(id) == null)
         return NoContent();
      _lawyerservice.Update(id, lawyer);
      return Ok(_lawyerservice.GetById(id));
   }

   [HttpDelete("lawyer/{id}")]
   public IActionResult Delete(int id)
   {
      if (_lawyerservice.GetById(id) == null)
         return NoContent();
      _lawyerservice.Delete(id);
      return Ok();
   }
}