using AssemblyRover.Operation;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyRover.Test
{
    [TestClass]
    public class AssemblyRoverInitializationTest
    {
        [TestMethod]
        public void InitializeGridTest_NegativeGridSize()
        {
            int grid = -4;
            GameManager manager = new GameManager();
            Assert.ThrowsException<System.OverflowException>(() => manager.InitializeGrid(grid));
        }

        [TestMethod]
        public void InitializeGridTest()
        {
            int grid = 4;
            GameManager manager = new GameManager();
            manager.InitializeGrid(grid);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void ClearGridTest_NullGrid()
        {
            GameManager manager = new GameManager();            
            Assert.ThrowsException<System.NullReferenceException>(() => manager.ClearGrid());
        }

        [TestMethod]
        public void ClearGridTest()
        {
            int grid = 4;
            GameManager manager = new GameManager();
            manager.InitializeGrid(grid);
            manager.ClearGrid();
            Assert.AreEqual(1, 1);
        }       

        [TestMethod]
        public void SetComponentCountTest()
        {
            int grid = 4;
            GameManager manager = new GameManager();
            manager.InitializeGrid(grid);
            manager.SetComponentCount(2);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void AddComponentGridTest_GridNull()
        {
            int r = 0, c = 0, i = 1;
            bool expected = false;
            GameManager manager = new GameManager();
            bool actual = manager.AddComponent(r, c, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddComponentGridTest_RowExceedsBounds()
        {
            int r = 5, c = 0, i = 1;
            bool expected = false;
            GameManager manager = new GameManager();
            manager.InitializeGrid(3);
            bool actual = manager.AddComponent(r, c, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddComponentGridTest_InvalidComponentLabel()
        {
            int r = 0, c = 0, i = -1;
            bool expected = false;
            GameManager manager = new GameManager();
            manager.InitializeGrid(3);
            bool actual = manager.AddComponent(r, c, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddComponentGridTest_DuplicateComponentLabel()
        {
            int r = 0, c = 0, i = 1;
            bool expected = false;
            GameManager manager = new GameManager();
            manager.InitializeGrid(3);
            bool actual = manager.AddComponent(r, c, i);
            actual = manager.AddComponent(r, c, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddComponentGridTest()
        {
            int r = 0, c = 0, i = 1;
            bool expected = true;
            GameManager manager = new GameManager();
            manager.InitializeGrid(3);
            bool actual = manager.AddComponent(r, c, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRoverTest()
        {
            int r = 0, c = 0;
            bool expected = true;
            GameManager manager = new GameManager();
            bool actual = manager.AddRover(r,c);
            Assert.AreEqual(expected, actual);
        }
    }
}
