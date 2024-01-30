using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence;
using TechAdvocacia.Core.Exceptions;

namespace TechAdvocacia.Application.Services;
public class DocumentService : IDocumentService {
    private readonly TechAdvocaciaDbContext _dbContext;

    public DocumentService(TechAdvocaciaDbContext dbContext) {
        _dbContext = dbContext;
    }

    public int Create(NewDocumentInputModel document) {
        var _legalCase = _dbContext.LegalCases.Find(document.LegalCaseId);
        var newDocument = new Document(){
            LegalCase = _legalCase ?? throw new LegalCaseNotFoundException()
        };
        _dbContext.Documents.Add(newDocument);
        _dbContext.SaveChanges();
        return newDocument.DocumentId;
    }

    public List<DocumentViewModel> GetAll() {
        var documents = _dbContext.Documents.ToList();
        return documents.Select(d => new DocumentViewModel(){
            DocumentId = d.DocumentId,
        }).ToList();
    }

    public DocumentViewModel? GetById(int id) {
        var document = _dbContext.Documents.Find(id);
        if(document == null) return null;
        return new DocumentViewModel(){
            DocumentId = document.DocumentId,
        };
    }

    public List<DocumentViewModel> GetByLegalCaseId(int LegalCaseId) {
        var documents = _dbContext.Documents.Where(d => d.LegalCaseId == LegalCaseId).ToList();
        return documents.Select(d => new DocumentViewModel(){
            DocumentId = d.DocumentId,
        }).ToList();
    }

    public void Update(int id, NewDocumentInputModel document) {
        var _document = _dbContext.Documents.Find(id);
        if(_document == null) throw new DocumentNotFoundException();
        _dbContext.SaveChanges();
    }

    public void Delete(int id) {
        var _document = _dbContext.Documents.Find(id);
        if(_document == null) throw new DocumentNotFoundException();
        _dbContext.Documents.Remove(_document);
        _dbContext.SaveChanges();
    }
}