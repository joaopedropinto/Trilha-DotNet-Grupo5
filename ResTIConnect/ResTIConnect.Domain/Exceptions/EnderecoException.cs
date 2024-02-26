namespace ResTIConnect.Domain.Exceptions;

public class EnderecoAlreadyExistsException : Exception
{
    public EnderecoAlreadyExistsException() :
        base("A endereco with this data already exists.")
    {
    }
}

public class EnderecoNotFoundException : Exception
{
    public EnderecoNotFoundException() :
        base("Endereco not found.")
    {
    }
}

