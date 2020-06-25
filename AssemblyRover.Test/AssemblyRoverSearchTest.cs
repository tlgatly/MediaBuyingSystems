using System;
using System.Collections.Generic;
using AssemblyRover.Entity;
using AssemblyRover.Operation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyRover.Test
{
    [TestClass]
    public class AssemblyRoverSearchTest
    {
        [TestMethod]
        public void StartSearchingTest_NullGrid()
        {
            GameManager manager = new GameManager();
            string expected = string.Empty;
            string actual = manager.StartSearching();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecursiveSearch_NullCell()
        {
            Rover rover = new Rover(0, 0);
            Grid grid = new Grid(3);
            int currentComponent = 1;
            string currentPath = string.Empty;
            List<string> output = new List<string>();

            GameManager manager = new GameManager();
            Assert.ThrowsException<System.NullReferenceException>(() => manager.RecursiveSearch(rover, grid, currentComponent, currentPath, output));
        }

        [TestMethod]
        public void RecursiveSearch_NullGrid()
        {
            Rover rover = new Rover(0, 0);
            Grid grid = null;
            int currentComponent = 1;
            string currentPath = string.Empty;
            List<string> output = new List<string>();

            GameManager manager = new GameManager();
            Assert.ThrowsException<System.NullReferenceException>(() => manager.RecursiveSearch(rover, grid, currentComponent, currentPath, output));
        }

        [TestMethod]
        public void RecursiveSearch_NullRover()
        {
            Rover rover = null;
            Grid grid = new Grid(3);
            int currentComponent = 1;
            string currentPath = string.Empty;
            List<string> output = new List<string>();

            GameManager manager = new GameManager();
            Assert.ThrowsException<System.NullReferenceException>(() => manager.RecursiveSearch(rover, grid, currentComponent, currentPath, output));
        }

        public void RecursiveSearch_PathNotFound()
        {
            Rover rover = new Rover(0, 0);
            Grid grid = new Grid(2)
            {
                ComponentCount = 2
            };
            grid.Cells[1, 1].HasComponent = true;
            grid.Cells[1, 1].Components.Add(1);
            int currentComponent = 1;
            string currentPath = string.Empty;
            List<string> output = new List<string>();
            bool expected = false;

            GameManager manager = new GameManager();
            bool actual = manager.RecursiveSearch(rover, grid, currentComponent, currentPath, output);
            Assert.AreEqual(expected, actual);
        }

        public void RecursiveSearch()
        {
            Rover rover = new Rover(0, 0);
            Grid grid = new Grid(2)
            {
                ComponentCount = 1
            };
            grid.Cells[1, 1].HasComponent = true;
            grid.Cells[1, 1].Components.Add(1);
            int currentComponent = 1;
            string currentPath = string.Empty;
            List<string> output = new List<string>();
            bool expected = true;

            GameManager manager = new GameManager();
            bool actual = manager.RecursiveSearch(rover, grid, currentComponent, currentPath, output);
            Assert.AreEqual(expected, actual);
        }
    }
}
