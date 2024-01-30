using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.Application.ViewModels
{
   public class LegalCaseViewModel
   {
      public int LegalCaseId { get; set; }
      public DateTime DataHora { get; set; }
      public ClientViewModel Client { get; set; } = null!;
      public LawyerViewModel Lawyer { get; set; } = null!;
   }
}