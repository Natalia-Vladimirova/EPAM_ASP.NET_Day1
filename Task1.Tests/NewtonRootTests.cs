using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task1.NewtonRoot;

namespace Task1.Tests
{
    [TestClass]
    public class NewtonRootTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountRoot_ValueIsPositiveRootDegreeIsNegative_ReturnedException()
        {
            double root = CountRoot(32, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountRoot_ValueIsPositiveRootDegreeIsZero_ReturnedException()
        {
            double root = CountRoot(32, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountRoot_ValueIsNegativeRootDegreeIsEven_ReturnedException()
        {
            double root = CountRoot(-81, 4);
        }

        [TestMethod]
        public void CountRoot_ValueIsZeroRootDegreeIsPositive_ReturnedZero()
        {
            //Arrange
            double arrangeRoot = 0;

            //Act
            double actRoot = CountRoot(0, 7);

            //Assert
            Assert.AreEqual(arrangeRoot, actRoot);
        }

        [TestMethod]
        public void CountRoot_ValueIsMinus27RootDegreeIs3_ReturnedMinus3()
        {
            //Arrange
            double arrangeRoot = -3;

            //Act
            double actRoot = CountRoot(-27, 3);

            //Assert
            Assert.AreEqual(arrangeRoot, actRoot);
        }

        [TestMethod]
        public void CountRoot_ValueIs81RootDegreeIs4_Returned3()
        {
            //Arrange
            double arrangeRoot = Math.Pow(81, (double)1 / 4);

            //Act
            double actRoot = CountRoot(81, 4);

            //Assert
            Assert.AreEqual(arrangeRoot, actRoot);
        }

    }
}
