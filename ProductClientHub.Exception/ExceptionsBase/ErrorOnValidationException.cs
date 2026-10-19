using System.Net;

namespace ProductClientHub.Exception.ExceptionsBase;

public class ErrorOnValidationException : ProductClientHubException
{
    private readonly List<string> _erros;
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _erros = errorMessages;
    }

    public override List<string> GetErrors() => _erros;

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}
