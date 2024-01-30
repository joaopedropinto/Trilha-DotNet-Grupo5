using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LegalCaseController : ControllerBase
{
   private readonly ILegalCaseService _legalcaseService;
   public List<LegalCaseViewModel> LegalCases => _legalcaseService.GetAll();
   public LegalCaseController(ILegalCaseService service) => _legalcaseService = service;
   [HttpGet("legalCase")]
   public IActionResult Get()
   {
      return Ok(LegalCases);

   }

   [HttpPost("legalCase")]
   public IActionResult Post([FromBody] NewLegalCaseInputModel legalCase)
   {
      _legalcaseService.Create(legalCase);
      return CreatedAtAction(nameof(Get), legalCase);
 
   }


}