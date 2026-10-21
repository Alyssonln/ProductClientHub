using System.Net;

namespace ProductClientHub.Exception.ExceptionsBase;

public class NotFoundException : ProductClientHubException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override List<string> GetErrors() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}
