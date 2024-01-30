namespace TechAdvocacia.Core.Entities;

public class Lawyer : Person {
    public int LawyerId {get; set;}
    //public required string CNA {get; set;}
    public ICollection<LegalCase>? LegalCases {get; set;}
}