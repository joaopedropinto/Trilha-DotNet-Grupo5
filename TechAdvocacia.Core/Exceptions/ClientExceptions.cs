namespace TechAdvocacia.Core.Exceptions
{
    public class ClientAlreadyExistsException : Exception
    {
        public ClientAlreadyExistsException() :
            base("A client with this data already exists.")
        {
        }
    }

    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() :
            base("Client not found.")
        {
        }
    }
}
