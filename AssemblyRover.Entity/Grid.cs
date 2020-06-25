using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover.Entity
{
    public class Grid
    {
        public int Size { get; set; }
        public int ComponentCount { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(int gridSize)
        {
            Size = gridSize;
            Cells = new Cell[gridSize,gridSize];
        }
    }
}
