using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Logging.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ToLogString(this Exception o, string msg)
        {
            // InnerException や　AggregateExceptions を分解して詳細まで表示したい。

            throw new NotImplementedException();
        }
    }
}
