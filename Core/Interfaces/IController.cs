using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IController<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
