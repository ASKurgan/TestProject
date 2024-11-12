using FluentValidation;
using TestProject.API.CommonValidators;
using TestProject.Domain.Base;

namespace TestProject.API.Requests.PublishProduct
{
    public class PublishProductRequestValidator : AbstractValidator<PublishProductRequest>
    {
        public PublishProductRequestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmptyWithError()
               .MaximumLengthWithError(Constraints.MEDIUM_TITLE_LENGTH);

            RuleFor(x => x.Description)
              .NotEmptyWithError()
              .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

            RuleFor(x => x.Price)
               .NotEmptyWithError();

            RuleFor(x => x.Amount)
              .NotEmptyWithError();

            RuleFor(x => x.DateCreate)
              .NotEmptyWithError();

            RuleFor(x => x.ExpirationDate)
              .NotEmptyWithError();
        }
      
    }
}
