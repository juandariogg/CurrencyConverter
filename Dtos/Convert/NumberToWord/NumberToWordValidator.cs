using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Convert.NumberToWord
{
    public class NumberToWordValidator : AbstractValidator<NumberToWordRequest>
    {
        public NumberToWordValidator()
        {
            this.RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Value must be greather than 0");

            this.RuleFor(x => x.Value)
                .LessThanOrEqualTo(999999999.99)
                .WithMessage("Value must be less than 999999999.99");
        }
    }
}
