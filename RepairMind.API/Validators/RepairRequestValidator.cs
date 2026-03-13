using FluentValidation;
using RepairMind.API.Models;

namespace RepairMind.API.Validators;

public class RepairRequestValidator : AbstractValidator<RepairRequest>
{
    public RepairRequestValidator()
    {
        RuleFor(x => x.ItemId)
            .NotEmpty().WithMessage("A repair request must reference an item.");

        RuleFor(x => x.ProblemDescription)
            .NotEmpty().WithMessage("Please describe the problem.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters.");
    }
}