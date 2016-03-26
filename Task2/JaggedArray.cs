using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    #region interfaces

    public interface ISortFeature
    {
        int CompareByFeature(int[] array1, int[] array2);
    }

    #endregion

    #region delegates

    public delegate int CompareByFeatureDelegate(int[] array1, int[] array2);

    #endregion

    #region array sorting

    public static class JaggedArray
    {
        public static void SortJaggedArray(int[][] array, ISortFeature comparer)
        {
            if (array == null) { throw new ArgumentNullException("Null array"); }
            if (comparer == null) { throw new ArgumentNullException("Null comparer"); }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.CompareByFeature(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] firstItem, ref int[] secondItem)
        {
            int[] temp = firstItem;
            firstItem = secondItem;
            secondItem = temp;
        }
    }

    #endregion

    #region sort features

    public class RowSumAscSorter : ISortFeature
    {
        // sort feature: row sum
        public int CompareByFeature(int[] array1, int[] array2)
        {
            if (array1 == null && array2 == null)
            { return 0; }

            if (array1 == null)
            { return 1; }
            
            if(array2 == null)
            { return -1; }

            if (array1.Length == 0 && array2.Length == 0)
            { return 0; }

            if (array1.Length == 0)
            { return 1; }

            if (array2.Length == 0)
            { return -1; }

            int arrayRowSum1 = CountRowSum(array1);
            int arrayRowSum2 = CountRowSum(array2);

            if (arrayRowSum1 < arrayRowSum2)
            { return -1; }

            if (arrayRowSum1 == arrayRowSum2)
            { return 0; }

            return 1;
        }

        private int CountRowSum(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
    }

    public class MaxElemModuleDescSorter : ISortFeature
    {
        // sort feature: max module of element
        public int CompareByFeature(int[] array1, int[] array2)
        {
            if (array1 == null && array2 == null)
            { return 0; }

            if (array1 == null)
            { return 1; }

            if (array2 == null)
            { return -1; }

            if (array1.Length == 0 && array2.Length == 0)
            { return 0; }

            if (array1.Length == 0)
            { return 1; }

            if (array2.Length == 0)
            { return -1; }

            int maxElemModule1 = FindMaxElemModule(array1);
            int maxElemModule2 = FindMaxElemModule(array2);

            if (maxElemModule1 > maxElemModule2)
            { return -1; }

            if (maxElemModule1 == maxElemModule2)
            { return 0; }

            return 1;
        }

        private int FindMaxElemModule(int[] array)
        {
            int max = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > max)
                {
                    max = Math.Abs(array[i]);
                }
            }
            return max;
        }
    }

    #endregion
}
