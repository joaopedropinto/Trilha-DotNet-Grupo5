namespace ResTIConnect.Domain.Exceptions;

public class UsuarioAlreadyExistsException : Exception
{
    public UsuarioAlreadyExistsException() :
        base("A usuario with this data already exists.")
    {
    }
}

public class UsuarioNotFoundException : Exception
{
    public UsuarioNotFoundException() :
        base("Usuario not found.")
    {
    }
}

