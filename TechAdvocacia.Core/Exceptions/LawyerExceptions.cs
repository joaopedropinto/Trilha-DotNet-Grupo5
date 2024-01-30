namespace TechAdvocacia.Core.Exceptions
{
    public class LawyerAlreadyExistsException : Exception
    {
        public LawyerAlreadyExistsException() :
            base("A lawyer with this data already exists.")
        {
        }
    }

    public class LawyerNotFoundException : Exception
    {
        public LawyerNotFoundException() :
            base("Lawyer not found.")
        {
        }
    }
}
