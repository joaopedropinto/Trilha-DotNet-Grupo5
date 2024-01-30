namespace TechAdvocacia.Core.Exceptions;
public class DocumentAlreadyExistsException : Exception
{
   public DocumentAlreadyExistsException() :
      base("A Document with these data already exists.")
   {
   }
}

public class DocumentNotFoundException : Exception
{
   public DocumentNotFoundException() :
      base("Document not found.")
   {
   }
}
