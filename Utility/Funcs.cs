using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public static class Funcs<T>
    {
        public static Func<T, T> Identity { get; } = x => x;
    }
}
