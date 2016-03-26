using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class JaggedArrayViaDelegate
    {
        public static void SortJaggedArray(int[][] array, ISortFeature comparer)
        {
            if (comparer == null) { throw new ArgumentNullException("Null comparer"); }

            SortJaggedArray(array, comparer.CompareByFeature);
        }

        public static void SortJaggedArray(int[][] array, CompareByFeatureDelegate compareByFeature)
        {
            if (array == null) { throw new ArgumentNullException("Null array"); }
            if (compareByFeature == null) { throw new ArgumentNullException("Null compare method"); }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (compareByFeature(array[j], array[j + 1]) > 0)
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

}
