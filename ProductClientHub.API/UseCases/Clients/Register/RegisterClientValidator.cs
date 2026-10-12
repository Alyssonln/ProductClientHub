using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientValidator : AbstractValidator<RequestClientJson>
{
    public RegisterClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
        RuleFor(client => client.Email).NotEmpty().WithMessage("O e-mail não pode ser vazio.");
    }
}
