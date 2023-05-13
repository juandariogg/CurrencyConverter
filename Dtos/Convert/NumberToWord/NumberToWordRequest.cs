using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos.Convert.NumberToWord
{
    public class NumberToWordRequest
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
