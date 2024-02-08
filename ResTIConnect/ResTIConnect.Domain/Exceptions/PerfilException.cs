namespace ResTIConnect.Domain.Exceptions;

public class PerfilAlreadyExistsException : Exception
{
    public PerfilAlreadyExistsException() :
        base("A perfil with this data already exists.")
    {
    }
}

public class PerfilNotFoundException : Exception
{
    public PerfilNotFoundException() :
        base("Perfil not found.")
    {
    }
}

