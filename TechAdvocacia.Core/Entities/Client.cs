namespace TechAdvocacia.Core.Entities;

public class Client : Person
{
    public int ClientId {get; set;}
    // public DateTime BirthDate {get; set;}
    // public string? MaritalStatus {get; set;}
    // public string? Profession {get; set;}
    public ICollection<LegalCase>? LegalCases {get; set;}
}