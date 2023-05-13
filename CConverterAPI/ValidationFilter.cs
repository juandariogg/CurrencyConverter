using Dtos.Error;
using FluentValidation;
using System.Net;

namespace CConverterAPI
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        private IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            this._validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            T? argToValidate = context.GetArgument<T>(0);

            if (_validator is not null)
            {
                var validationResult = await _validator.ValidateAsync(argToValidate!);
                if (!validationResult.IsValid)
                {

                    return Results.UnprocessableEntity(new ValidationError() 
                    { 
                        Description = "One or more errors during validation", 
                        Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                        StatusCode = (int)HttpStatusCode.UnprocessableEntity
                    });
                }
            }

            // Otherwise invoke the next filter in the pipeline
            return await next.Invoke(context);
        }
    }
}
