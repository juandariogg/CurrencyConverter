using Core.Interface.Convert;
using Dtos.Convert.NumberToWord;

namespace Controllers.Convert
{
    public class NumberToWordController : IController<NumberToWordRequest, NumberToWordResponse>
    {
        private readonly INumberToWordService service;
        public NumberToWordController(INumberToWordService service) 
        {
            this.service = service;
        }

        public NumberToWordResponse Handle(NumberToWordRequest request)
        {
            return new NumberToWordResponse() { Value = service.ToWord(request.Value) };
        }
    }
}
