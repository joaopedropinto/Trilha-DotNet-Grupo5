namespace TechAdvocacia.Core.Entities;

public class LegalCase : BaseEntity
{
    public DateTime Opening {get; set;}
    public float SuccessProbability {get; set;}
    public List<Document>? Documents {get; set;} = new();
    public List<(float, string)>? Costs {get; set;}
    public DateTime Closing {get; set;}
    public List<Lawyer>? Lawyers {get; set;}
    public int ClientId {get; set;}
    public Client? Client {get; set;}
    public string? Status {get; set;}

}