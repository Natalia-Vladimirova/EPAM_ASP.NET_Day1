using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.NUnitTests
{
    [TestFixture]
    public class JaggedArrayTests
    {
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullArray()
        {
            JaggedArray.SortJaggedArray(null, new AscendingSortOrder(), new RowSumSortFeature());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullSortOrder()
        {
            JaggedArray.SortJaggedArray(new int[][] { new int[] { 1 } }, null, new RowSumSortFeature());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullSortFeature()
        {
            JaggedArray.SortJaggedArray(new int[][] { new int[] { 1 } }, new AscendingSortOrder(), null);
        }

        [TestCase]
        public void SortJaggedArray_AscendingOrder_RowSumSortFeature()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { },
                new int[] { 2, 3, 5 },
                new int[] { 2, 4, 7, 5 },
                new int[] { 20 },
                new int[] { 1, 4, 8, 100 },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { 2, 3, 5 },
                new int[] { 1, 4, 8, 100 },
                null,
                new int[] { 20 },
                null,
                null,
                new int[] { 2, 4, 7, 5 },
                new int[] { },
                null
            };

            JaggedArray.SortJaggedArray(actArray, new AscendingSortOrder(), new RowSumSortFeature());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }

        [TestCase]
        public void SortJaggedArray_DescendingOrder_MaxElemModuleSortFeature()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { },
                new int[] { 1, 4, 8, -100 },
                new int[] { 20 },
                new int[] { 2, 4, -7, 5 },
                new int[] { 2, 3, 5 },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { 2, 3, 5 },
                new int[] { 1, 4, 8, -100 },
                null,
                new int[] { 20 },
                null,
                null,
                new int[] { 2, 4, -7, 5 },
                new int[] { },
                null
            };

            JaggedArray.SortJaggedArray(actArray, new DescendingSortOrder(), new MaxElemModuleSortFeature());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }


    }
}
