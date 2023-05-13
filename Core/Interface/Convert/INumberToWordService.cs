using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Convert
{
    public interface INumberToWordService
    {
        string ToWord(double number);
    }
}
