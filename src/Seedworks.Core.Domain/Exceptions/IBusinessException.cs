using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seedworks.Core.Domain.Exceptions
{
    public interface IBusinessException
    {
        string? GetCode();
        string GetMessage();
    }
}
