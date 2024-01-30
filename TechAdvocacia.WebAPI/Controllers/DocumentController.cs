using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;

namespace TechAdvocacia.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]

public class DocumentController : ControllerBase {
    private readonly IDocumentService _documentService;
    public List<DocumentViewModel> Documents => _documentService.GetAll();
    public DocumentController(IDocumentService service) => _documentService = service;

    [HttpGet("documents")]
    public IActionResult Get(){
        return Ok(Documents);
    }

    [HttpGet("documents/{id}")]
    public IActionResult GetById(int id){
        try{
            var document = _documentService.GetById(id);
            return Ok(document);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("document")]
    public IActionResult Post([FromBody] NewDocumentInputModel document){
        _documentService.Create(document);
        return CreatedAtAction(nameof(Get), document);
    }
}
