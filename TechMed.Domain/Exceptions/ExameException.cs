namespace TechMed.Domain.Exceptions;
public class ExameAlreadyExistsException : Exception
{
   public ExameAlreadyExistsException() :
      base("Já existe um exame com esses dados.")
   {
   }
}

public class ExameNotFoundException : Exception
{
   public ExameNotFoundException() :
      base("Exame não encontrado.")
   {
   }
}