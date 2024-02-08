namespace ResTIConnect.Domain.Exceptions;

public class SistemaAlreadyExistsException : Exception
{
    public SistemaAlreadyExistsException() :
        base("A sistema with this data already exists.")
    {
    }
}

public class SistemaNotFoundException : Exception
{
    public SistemaNotFoundException() :
        base("Sistema not found.")
    {
    }
}

