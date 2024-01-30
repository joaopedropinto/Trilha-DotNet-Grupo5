using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Core.Exceptions
{
    public class LegalCaseAlreadyExistsException : Exception
    {
        public LegalCaseAlreadyExistsException() :
            base("A LegalCase with this data already exists.")
        {
        }
    }

    public class LegalCaseNotFoundException : Exception
    {
        public LegalCaseNotFoundException() :
            base("LegalCase not found.")
        {
        }
    }
}
