using Dtos.Convert.NumberToWord;
using Core.Interface.Convert;

namespace CConverterAPI.api.v1
{
    public class ConvertEndpoints
    {
        public NumberToWordResponse NumberToWord(NumberToWordRequest dto, IController<NumberToWordRequest, NumberToWordResponse> controller)
        {
            return controller.Handle(dto);
        }
    }
}
