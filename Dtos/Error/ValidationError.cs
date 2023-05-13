using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Error
{
    public class ValidationError
    {
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
