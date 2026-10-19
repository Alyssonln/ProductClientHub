using System.Net;

namespace ProductClientHub.Exception.ExceptionsBase;

public abstract class ProductClientHubException : SystemException
{
    public ProductClientHubException(string message) : base(message)
    {
    }

    public abstract List<string> GetErrors();

    public abstract HttpStatusCode GetHttpStatusCode();
}
