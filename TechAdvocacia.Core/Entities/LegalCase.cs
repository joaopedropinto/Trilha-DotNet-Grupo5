namespace TechAdvocacia.Core.Entities;

public class LegalCase : BaseEntity
{
    public int LegalCaseId {get; set;}
    public DateTime Opening {get; set;}
    public float SuccessProbability {get; set;}
    public string? Status {get; set;}
    public DateTime Closing {get; set;}
    public ICollection<Document>? Documents {get; set;}
    // public ICollection<(float, string)>? Costs {get; set;}
    public int LawyerId { get; set; }
    public Lawyer? Lawyer {get; set;}
    public int ClientId {get; set;}
    public Client? Client {get; set;}
}