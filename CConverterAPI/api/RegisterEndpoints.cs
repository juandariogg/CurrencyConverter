using Dtos.Converter.NumeralToWordConverter;

namespace CConverterAPI.api
{
    public static class RegisterEndpoints
    {
        public static void UseApplicationEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/convert/numeraltowordconverter", new v1.ConverterEndpoints().NumeralToWordConverter)
                .AddEndpointFilter<ValidationFilter<NumeralToWordRequest>>();
        }
    }
}
