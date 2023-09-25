namespace FastFoodClassification.Utilities.Exceptions;

public class ClassificationsException : Exception
{
    public ClassificationsException()
    {
    }

    public ClassificationsException(string message) : base(message)
    {
    }

    public ClassificationsException(string message, Exception inner) : base(message, inner)
    {
    }
}