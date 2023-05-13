using Dtos.Converter.NumeralToWordConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Controllers.Converter.NumeralToWordConverter
{
    public class NumeralToWordConverterController : IController<NumeralToWordRequest, NumeralToWordResponse>
    {
        private INumeralToWordConverterService _service;

        public NumeralToWordConverterController(INumeralToWordConverterService service)
        {
            this._service = service;
        }

        public Task<NumeralToWordResponse> Handle(NumeralToWordRequest request)
        {
            return Task.FromResult(new NumeralToWordResponse() { Value = _service.ToWord(request.Value) });
        }
    }
}
