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
            JaggedArray.SortJaggedArray(null, new RowSumAscSorter());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullSortFeature()
        {
            JaggedArray.SortJaggedArray(new int[][] { new int[] { 1 } }, null);
        }

        [TestCase]
        public void SortJaggedArray_RowSumAscSorter()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 2, 3, 5 },
                new int[] { 2, 4, 7, 5 },
                new int[] { 20 },
                new int[] { 1, 4, 8, 100 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
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

            JaggedArray.SortJaggedArray(actArray, new RowSumAscSorter());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }

        [TestCase]
        public void SortJaggedArray_MaxElemModuleDescSorter()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 1, 4, 8, -100 },
                new int[] { 20 },
                new int[] { 2, 4, -7, 5 },
                new int[] { 2, 3, 5 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
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

            JaggedArray.SortJaggedArray(actArray, new MaxElemModuleDescSorter());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }
    }

    [TestFixture]
    public class JaggedArrayViaDelegateTests
    {
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullArray()
        {
            JaggedArrayViaDelegate.SortJaggedArray(null, new RowSumAscSorter());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullSortFeature()
        {
            JaggedArrayViaDelegate.SortJaggedArray(new int[][] { new int[] { 1 } }, (CompareByFeatureDelegate)null);
        }

        [TestCase]
        public void SortJaggedArray_Delegate_RowSumAscSort()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 1, 4, 8, -100 },
                new int[] { 2, 3, 5 },
                new int[] { 2, 4, 7, 5 },
                new int[] { 20 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
                new int[] { 2, 3, 5 },
                new int[] { 1, 4, 8, -100 },
                null,
                new int[] { 20 },
                null,
                null,
                new int[] { 2, 4, 7, 5 },
                new int[] { },
                null
            };

            JaggedArrayViaDelegate.SortJaggedArray(actArray, new RowSumAscSorter().CompareByFeature);

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }

        [TestCase]
        public void SortJaggedArray_Interface_MaxElemModuleDescSort()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 1, 4, 8, -100 },
                new int[] { 20 },
                new int[] { 2, 4, -7, 5 },
                new int[] { 2, 3, 5 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
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

            JaggedArrayViaDelegate.SortJaggedArray(actArray, new MaxElemModuleDescSorter());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }
    }

    [TestFixture]
    public class JaggedArrayViaInterfaceTests
    {
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullArray()
        {
            JaggedArrayViaInterface.SortJaggedArray(null, new RowSumAscSorter());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void SortJaggedArray_NullSortFeature()
        {
            JaggedArrayViaInterface.SortJaggedArray(new int[][] { new int[] { 1 } }, (ISortFeature)null);
        }

        [TestCase]
        public void SortJaggedArray_Interface_RowSumAscSort()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 1, 4, 8, -100 },
                new int[] { 2, 3, 5 },
                new int[] { 2, 4, 7, 5 },
                new int[] { 20 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
                new int[] { 2, 3, 5 },
                new int[] { 1, 4, 8, -100 },
                null,
                new int[] { 20 },
                null,
                null,
                new int[] { 2, 4, 7, 5 },
                new int[] { },
                null
            };

            JaggedArrayViaInterface.SortJaggedArray(actArray, new RowSumAscSorter());

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }

        [TestCase]
        public void SortJaggedArray_Delegate_MaxElemModuleDescSort()
        {
            //Arrange
            int[][] arrangeArray = new int[][]
            {
                new int[] { 1, 4, 8, -100 },
                new int[] { 20 },
                new int[] { 2, 4, -7, 5 },
                new int[] { 2, 3, 5 },
                new int[] { },
                new int[] { },
                null,
                null,
                null,
                null
            };

            //Act
            int[][] actArray = new int[][]
            {
                new int[] { },
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

            JaggedArrayViaInterface.SortJaggedArray(actArray, new MaxElemModuleDescSorter().CompareByFeature);

            //Assert
            Assert.AreEqual(arrangeArray, actArray);
        }
    }

}
