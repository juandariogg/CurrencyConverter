using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Converter.NumeralToWordConverter
{
    public class NumeralToWordValidator : AbstractValidator<NumeralToWordRequest>
    {
        public NumeralToWordValidator()
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Number value must be equal or greater than 0");

            RuleFor(x => x.Value)
                .LessThanOrEqualTo(999999999.99)
                .WithMessage("Numer value must be equal or smaller than 999.999.999,99");
        }
    }
}
