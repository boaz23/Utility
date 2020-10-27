using System;
using System.Diagnostics;

namespace ManualTests
{
    class Program
    {
        public static void Main(string[] args)
        {
            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now - TimeSpan.FromSeconds(100);
            var t = a - b;
        }

        private static void Pause()
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
#endif
        }
    }
}
