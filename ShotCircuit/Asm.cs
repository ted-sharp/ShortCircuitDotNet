using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit
{
    public static class Asm
    {

        public static string Version
            => Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? "";

        public static string Location
            => Assembly.GetEntryAssembly()?.Location ?? "";
    }
}
