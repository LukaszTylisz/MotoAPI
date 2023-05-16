using FluentValidation;
using MotoAPI.Entitites;

namespace MotoAPI.Models.Validators;

public class MotoQueryValidator : AbstractValidator<MotoQuery>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    private string[] allowedSortByColumnNames =
        { nameof(Moto.Name), nameof(Moto.Category), nameof(Moto.Description), };

    public MotoQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(r => r.PageSize).Custom((value, context) =>
        {
            if (!allowedPageSizes.Contains(value))
            {
                context.AddFailure("PageSize", $"Pagesize must int [{string.Join(",", allowedPageSizes)}]");
            }
        });

        RuleFor(r => r.SortBy)
            .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}