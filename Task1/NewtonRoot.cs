using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task1
{
    public static class NewtonRoot
    {
        private const double Precision = 1e-15;
        public static double CountRoot(double value, int rootDegree)
        {
            if (rootDegree <= 0)
                return double.NaN;

            if ((value < 0) && (rootDegree % 2 == 0))
                return double.NaN;

            if (value == 0)
                return 0;

            double resultRoot = 0;
            double previousRoot = 1;
            while (true)
            {
                resultRoot = ((rootDegree - 1) * previousRoot + value / Pow(previousRoot, rootDegree - 1)) / rootDegree;
                if (Abs(resultRoot - previousRoot) < Precision)
                    break;
                previousRoot = resultRoot;
            }
            return resultRoot;
        }

    }
}
