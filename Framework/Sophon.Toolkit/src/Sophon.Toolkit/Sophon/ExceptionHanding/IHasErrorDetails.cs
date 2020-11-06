using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Toolkit.ExceptionHanding
{
    public interface IHasErrorDetails
    {
        string Details { get; }
    }
}
