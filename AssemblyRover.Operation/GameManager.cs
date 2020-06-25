using AssemblyRover.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover.Operation
{
    public class GameManager
    {
        private Grid grid;
        private Rover rover;

        public void InitializeGrid(int gridSize)
        {
            grid = new Grid(gridSize);
            for(int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid.Cells[i,j] = new Cell();
                }
            }
        }

        public void ClearGrid()
        {
            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    grid.Cells[i,j].IsVisited = false;
                }
            }
        }

        public void SetComponentCount(int count)
        {
            if (grid != null)
                grid.ComponentCount = count;
        }

        public bool AddComponent(int r, int c, int number)
        {
            try
            {
                if (grid == null || grid.Size == 0 || grid.Cells == null || grid.Cells.Length == 0)
                    return false;
                if (r < 0 || r >= grid.Size || c < 0 || c >= grid.Size || number <= 0)
                    return false;
                Cell cell = grid.Cells[r,c];
                if (cell.Components.Contains(number))
                    return false;
                cell.Components.Add(number);
                cell.HasComponent = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRover(int r, int c)
        {
            try
            {
                rover = new Rover(r, c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string StartSearching()
        {
            try
            {
                List<string> output = new List<string>();
                int currentComponent = 1;
                if (grid != null)
                {
                    while (currentComponent <= grid.ComponentCount)
                    {
                        string currentPath = string.Empty;
                        if (RecursiveSearch(rover, grid, currentComponent, currentPath, output))
                        {
                            currentComponent++;
                            ClearGrid();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                StringBuilder stringBuilder = new StringBuilder();
                foreach (string path in output)
                    stringBuilder.Append(path);
                return stringBuilder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool RecursiveSearch(Rover rover, Grid grid, int currentComponent, string currentPath, List<string> output)
        {
            Cell c = grid.Cells[rover.Row,rover.Column];
            if (c.IsVisited)
                return false;
            c.IsVisited = true;
            if (c.HasComponent && c.Components.Contains(currentComponent)) {
                output.Add(currentPath);
                c.Components.Remove(currentComponent);
                if (c.Components.Count == 0)
                    c.HasComponent = false;
                return true;
            }

            int originalRow = rover.Row;
            int originalColumn = rover.Column;

            rover.Row = originalRow + 1; // N
            rover.Column = originalColumn;
            if (IsValid(rover.Row, rover.Column) && RecursiveSearch(rover, grid, currentComponent, currentPath + "N", output))
                return true;

            rover.Row = originalRow - 1; // S
            rover.Column = originalColumn;
            if (IsValid(rover.Row, rover.Column) && RecursiveSearch(rover, grid, currentComponent, currentPath + "S", output))
                return true;

            rover.Row = originalRow; // E
            rover.Column = originalColumn + 1;
            if (IsValid(rover.Row, rover.Column) && RecursiveSearch(rover, grid, currentComponent, currentPath + "E", output))
                return true;

            rover.Row = originalRow; // W
            rover.Column = originalColumn - 1;
            if (IsValid(rover.Row, rover.Column) && RecursiveSearch(rover, grid, currentComponent, currentPath + "W", output))
                return true;

            return false;
        }

        public bool IsValid(int r, int c)
        {
            return r >= 0 && r < grid.Size && c >= 0 && c < grid.Size;
        }
    }
}
