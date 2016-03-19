using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    #region interfaces

    public interface ISortOrder
    {
        int SortingMethod(int x, int y);
    }

    public interface ISortFeature
    {
        int FindSortFeature(int[] array);
    }

    #endregion

    #region array sorting

    public static class JaggedArray
    {
        public static void SortJaggedArray(int[][] array, ISortOrder sortOrder, ISortFeature sortFeature)
        {
            if (array == null) { throw new ArgumentNullException(); }

            if (sortOrder == null) { throw new ArgumentNullException(); }

            if (sortFeature == null) { throw new ArgumentNullException(); }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if ((array[j] == null) || (array[j + 1] != null && array[j + 1].Length == 0) ||
                        (array[j + 1] != null && array[j].Length != 0 &&
                        sortOrder.SortingMethod(sortFeature.FindSortFeature(array[j]), sortFeature.FindSortFeature(array[j + 1])) > 0))
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

    #region sort order

    public class AscendingSortOrder : ISortOrder
    {
        // ascending method
        public int SortingMethod(int x, int y)
        {
            return x > y ? 1 : x == y ? 0 : -1;
        }
    }

    public class DescendingSortOrder : ISortOrder
    {
        // descending method
        public int SortingMethod(int x, int y)
        {
            return x < y ? 1 : x == y ? 0 : -1;
        }
    }

    #endregion

    #region sort features

    public class RowSumSortFeature : ISortFeature
    {
        // sort feature: row sum
        public int FindSortFeature(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
    }

    public class MaxElemModuleSortFeature : ISortFeature
    {
        // sort feature: max module of element
        public int FindSortFeature(int[] array)
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
