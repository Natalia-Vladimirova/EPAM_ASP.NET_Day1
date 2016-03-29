using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class JaggedArrayViaInterface
    {
        public static void SortJaggedArray(int[][] array, CompareByFeatureDelegate compareDelegate)
        {
            SortJaggedArray(array, new JaggedArrayAdapter(compareDelegate));
        }

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

        private class JaggedArrayAdapter : ISortFeature
        {
            private CompareByFeatureDelegate compareDelegate;

            public JaggedArrayAdapter(CompareByFeatureDelegate compareDelegate)
            {
                if (compareDelegate == null)
                {
                    throw new ArgumentNullException("Null compare method");
                }
                this.compareDelegate = compareDelegate;
            }

            public int CompareByFeature(int[] array1, int[] array2) => 
                compareDelegate(array1, array2);           
        }
    }

}
