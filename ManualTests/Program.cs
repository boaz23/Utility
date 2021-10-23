using System;
using System.Diagnostics;

namespace ManualTests
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{Utility.Numbers.BitCount(long.MinValue)}");
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
