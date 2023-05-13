using Core;
using FluentValidation;
using FluentValidation.Results;

namespace CConverterAPI.api
{
    public class APIFilter<T> : IEndpointFilter
    {
        private IValidator<T> validator;
        public APIFilter(IValidator<T> validator) 
        {
            this.validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            T item = context.GetArgument<T>(0);

            if (validator == null || item == null)
                return await next(context);

            ValidationResult vresult = validator.Validate(item);
            if (!vresult.IsValid)
            {
                return Results.UnprocessableEntity(new ErrorModel()
                { 
                    Status = (int)StatusCodes.Status422UnprocessableEntity,
                    Message = "One or more validation errors occurred",
                    Errors = vresult.Errors.Select(x => x.ErrorMessage).ToArray()
                });
            }

            return await next(context);
        }
    }
}
