namespace ResTIConnect.Domain.Exceptions;

public class EventoAlreadyExistsException : Exception
{
    public EventoAlreadyExistsException() :
        base("A evento with this data already exists.")
    {
    }
}

public class EventoNotFoundException : Exception
{
    public EventoNotFoundException() :
        base("Evento not found.")
    {
    }
}

