using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos.Converter.NumeralToWordConverter
{
    public class NumeralToWordRequest
    {
        [JsonPropertyName("value")]
        public Double Value { get; set; }
    }
}
