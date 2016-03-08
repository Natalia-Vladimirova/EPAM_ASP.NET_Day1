using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static Task1.NewtonRoot;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteOnConsole(0, 3);
            WriteOnConsole(16, 2);
            WriteOnConsole(81, 2);
            WriteOnConsole(1024, 5);
            WriteOnConsole(78, 5);
            WriteOnConsole(10000000, 7);
            WriteOnConsole(0.078, 6);
            WriteOnConsole(1.2e-12, 3);
            WriteOnConsole(1.2e+12, 3);
            WriteOnConsole(12000, -3);
            WriteOnConsole(-81, 2);
            WriteOnConsole(-243, 5);

            ReadKey();
        }

        static void WriteOnConsole(double value, int rootDegree)
        {
            WriteLine($"value: {value}, root degree: {rootDegree}");
            WriteLine($"NewtonRoot:\t{CountRoot(value, rootDegree)}");
            WriteLine($"Math.Pow:\t{Pow(value, (double)1 / rootDegree)}");
            WriteLine();
        }
    }
}
