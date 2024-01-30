namespace TechAdvocacia.Core.Entities;

public class Document : BaseEntity {
    public int DocumentId {get; set;}
    public int LegalCaseId { get; set; }
    public required LegalCase LegalCase { get; set; }
    //public DateTime DateModification {get; set;}
    //public string Type {get; set;}
    //public string Description {get; set;}
}