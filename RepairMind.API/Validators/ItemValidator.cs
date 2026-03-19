using FluentValidation;
using RepairMind.Core.Models;

namespace RepairMind.API.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Item must have a name.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Item must have a category.");
    }
}