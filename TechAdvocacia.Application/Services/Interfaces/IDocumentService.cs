namespace TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

public interface IDocumentService{
    public List<DocumentViewModel> GetAll();
    public DocumentViewModel? GetById(int id);
    public List<DocumentViewModel> GetByLegalCaseId(int LegalCaseId);
    public int Create(NewDocumentInputModel document);
    public void Update(int id, NewDocumentInputModel document);
    public void Delete(int id);
}