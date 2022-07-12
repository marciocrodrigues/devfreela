using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Descrição é de 255 caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Títutlo é de 30 caracteres.");

            RuleFor(p => p.IdFreelancer)
                .NotNull()
                .NotEmpty()
                .WithMessage("Identificador do freelancer obrigatório.")
                .LessThanOrEqualTo(0)
                .WithMessage("O identificador do freelancer deve ser maior que zero.");

            RuleFor(p => p.IdClient)
                .NotNull()
                .NotEmpty()
                .WithMessage("Identificador do cliente obrigatório.")
                .LessThanOrEqualTo(0)
                .WithMessage("O identificador do cliente deve ser maior que zero.");
        }


    }
}
