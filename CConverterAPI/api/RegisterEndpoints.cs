using CConverterAPI.api.v1;
using Dtos.Convert.NumberToWord;

namespace CConverterAPI.api
{
    public static class RegisterEndpoints
    {
        public static void AddEndpoints(this WebApplication app)
        {
            app.MapPost("/api/v1/convert/numbertoword", new ConvertEndpoints().NumberToWord).AddEndpointFilter<APIFilter<NumberToWordRequest>>();
        }
    }
}
