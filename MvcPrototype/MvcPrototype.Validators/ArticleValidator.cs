using FluentValidation;
using MvcPrototype.Models;
 
namespace MvcValidation.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).Length(20, 200).WithMessage("Description must be 20-200 characters long.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}