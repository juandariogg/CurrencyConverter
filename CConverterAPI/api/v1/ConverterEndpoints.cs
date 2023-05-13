using Core.Interfaces;
using Dtos.Converter.NumeralToWordConverter;
using FluentValidation;

namespace CConverterAPI.api.v1
{
    public class ConverterEndpoints
    {
        public async Task<NumeralToWordResponse> NumeralToWordConverter(NumeralToWordRequest dto, IController<NumeralToWordRequest, NumeralToWordResponse> controller)
        {
            return await controller.Handle(dto);
        }
    }
}
