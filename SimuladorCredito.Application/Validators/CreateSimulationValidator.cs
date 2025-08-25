using FluentValidation;
using SimuladorCredito.Application.Dtos.Requests;

namespace SimuladorCredito.Application.Validators
{
    public class CreateSimulationValidator : AbstractValidator<CreateSimulationDto>
    {
        public CreateSimulationValidator()
        {
            RuleFor(dto => dto.ValorDesejado)
                .GreaterThan(0)
                .WithMessage("O valor desejado deve ser maior que zero");

            RuleFor(dto => dto.prazo)
                .GreaterThan((short)0)
                .WithMessage("O prazo deve ser maior que zero");
        }
    }
}