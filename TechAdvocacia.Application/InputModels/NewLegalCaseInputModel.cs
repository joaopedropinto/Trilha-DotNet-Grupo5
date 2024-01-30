namespace TechAdvocacia.Application.InputModels
{
    public class NewLegalCaseInputModel
    {
        public DateTime Opening { get; set; }
        // public string Cpf { get; set; }
        public int LawyerId { get; set; }
        public int ClientId { get; set; }
    }
}