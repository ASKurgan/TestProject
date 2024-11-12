using FluentValidation;
using TestProject.API.CommonValidators;
using TestProject.Domain.Base;

namespace TestProject.API.Requests.ProductCategory
{
    public class PCRequestValidator : AbstractValidator<PCRequest>
    {
        public PCRequestValidator() 
        {

            RuleFor(x => x.Name)
               .NotEmptyWithError()
               .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

            RuleFor(x => x.Description)
               .NotEmptyWithError()
               .MaximumLengthWithError(Constraints.MEDIUM_TITLE_LENGTH);

          
        }
    }
}
