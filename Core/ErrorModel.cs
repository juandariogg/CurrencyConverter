using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ErrorModel
    {
        public int Status { get; set; }
        public string Message { get; set; } = null!;

        public string[] Errors { get; set; } = null!;
    }
}
