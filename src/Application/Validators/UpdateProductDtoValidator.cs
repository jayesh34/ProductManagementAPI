using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.ModifiedBy)
            .NotEmpty()
            .MaximumLength(100);
    }
}