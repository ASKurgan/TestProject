using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestProject.Domain.Base.Error;
using TestProject.Domain.Base;
using FluentValidation;

namespace TestProject.API.CommonValidators
{
    public static class CustomValidators
    {
         public static IRuleBuilderOptions<T, TProperty> NotEmptyWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithError(Errors.General.ValueIsRequired());
        }

        public static IRuleBuilderOptions<T, string> MaximumLengthWithError<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int maxLength)
        {
            return ruleBuilder
                .MaximumLength(maxLength)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, string> MinimumLengthWithError<T>(
          this IRuleBuilder<T, string> ruleBuilder,
          int minLength)
        {
            return ruleBuilder
                .MinimumLength(minLength)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty> GreaterThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty?> GreaterThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty> LessThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .LessThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }
       
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, Error error)
        {
            return rule
                .WithMessage(error.Serialize());
        }
    }
}
