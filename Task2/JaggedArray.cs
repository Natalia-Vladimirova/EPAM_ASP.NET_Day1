using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate int SortingMethodDelegate(int x, int y);
    public delegate int SortingByDelegate(int[] array);

    public static class JaggedArray
    {
        public static void SortJaggedArray(int[][] array, SortingMethodDelegate sortingMethod, SortingByDelegate sortingBy)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (sortingMethod == null)
                sortingMethod = SortingMethod.Ascending;

            if (sortingBy == null)
                sortingBy = SortingBy.RowSum;

            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if ((array[j] == null) || (array[j + 1] != null && array[j + 1].Length == 0) ||
                        (array[j + 1] != null && array[j].Length != 0 &&
                        sortingMethod(sortingBy(array[j]), sortingBy(array[j + 1])) > 0))
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
        }

    }

    public static class SortingMethod
    {
        public static SortingMethodDelegate Ascending { get; } = AscendingMethod;
        public static SortingMethodDelegate Descending { get; } = DescendingMethod;

        private static int AscendingMethod(int x, int y)
        {
            return x > y ? 1 : x == y ? 0 : -1;
        }

        private static int DescendingMethod(int x, int y)
        {
            return x < y ? 1 : x == y ? 0 : -1;
        }
    }

    public static class SortingBy
    {
        public static SortingByDelegate RowSum { get; } = FindRowSum;
        public static SortingByDelegate Max { get; } = FindMax;
        public static SortingByDelegate Min { get; } = FindMin;

        private static int FindRowSum(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }

        private static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > max)
                    max = array[i];
            return max;
        }

        private static int FindMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] < min)
                    min = array[i];
            return min;
        }
    }

}
