namespace ResTIConnect.Domain.Exceptions;

public class LogAlreadyExistsException : Exception
{
    public LogAlreadyExistsException() :
        base("A log with this data already exists.")
    {
    }
}

public class LogNotFoundException : Exception
{
    public LogNotFoundException() :
        base("Log not found.")
    {
    }
}

