using FluentValidation;
using HranaLibrary.Models;

namespace HranaLibrary.Validation
{
    public class Recipe_Validation : AbstractValidator<Recipe>
    {
        public Recipe_Validation()
        {
            RuleFor(x => x.RecipeName).NotEmpty().WithMessage("Recipe name is required!");
        }
    }
}
