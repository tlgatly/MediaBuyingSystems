using AssemblyRover.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            // Grid creation
            Console.WriteLine("Please enter grid size:");
            int size = 0;
            while (size <= 0 || size > 100)
            {
                string gridSize = Console.ReadLine();
                if (!Int32.TryParse(gridSize, out size) || size <= 0 || size > 100)
                {
                    Console.WriteLine("Please enter a valid grid size between 1 and 100.");
                }
            }
            game.InitializeGrid(size);

            // Component count
            Console.WriteLine("Please enter component count:");
            int componentCount = 0;
            while (componentCount <= 0)
            {
                string componentCountStr = Console.ReadLine();
                if (!Int32.TryParse(componentCountStr, out componentCount) || componentCount <= 0)
                {
                    Console.WriteLine("Please enter a valid component count greater than 0.");
                }
            }
            game.SetComponentCount(componentCount);

            // Component locations
            int i = 1;
            while (i <= componentCount)
            {
                Console.WriteLine(string.Format("Please enter component {0} row and column respectively (ex: r,c):", i));
                int componentR = -1;
                int componentC = -1;
                while (componentR < 0 || componentC < 0 || componentR >= size || componentC >= size)
                {
                    string componentLocation = Console.ReadLine();
                    string[] coordinates = componentLocation.Split(',');
                    if(coordinates.Length == 2)
                    {
                        if (!Int32.TryParse(coordinates[0], out componentR) || componentR < 0 || componentR >= size)
                        {
                            Console.WriteLine("Please enter a valid component row between 0 and " + (size - 1));
                            continue;
                        }
                        if (!Int32.TryParse(coordinates[1], out componentC) || componentC < 0 || componentC >= size)
                        {
                            Console.WriteLine("Please enter a valid component column between 0 and " + (size - 1));
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter two valid coordinates between 0 and " + (size - 1));
                    }
                    
                }
                game.AddComponent(componentR, componentC, i);
                i++;
            }

            // Rover location
            Console.WriteLine(string.Format("Please enter rover row and column respectively (ex: r,c):", i));
            int roverR = -1;
            int roverC = -1;
            while (roverR < 0 || roverC < 0 || roverR >= size || roverC >= size)
            {
                string roverLocation = Console.ReadLine();
                string[] coordinates = roverLocation.Split(',');
                if (coordinates.Length == 2)
                {
                    if (!Int32.TryParse(coordinates[0], out roverR) || roverR < 0 || roverR >= size)
                    {
                        Console.WriteLine("Please enter a valid rover row between 0 and " + (size - 1));
                        continue;
                    }
                    if (!Int32.TryParse(coordinates[1], out roverC) || roverC < 0 || roverC >= size)
                    {
                        Console.WriteLine("Please enter a valid rover column between 0 and " + (size - 1));
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter two valid coordinates between 0 and " + (size - 1));
                }
            }
            game.AddRover(roverR, roverC);

            // Start searching
            Console.WriteLine("Please press enter to start searching");
            string start = Console.ReadLine();
            string outputPath = game.StartSearching();

            if(string.IsNullOrEmpty(outputPath))
            {
                Console.WriteLine("No path found.");
            }
            else
            {
                Console.WriteLine("Result: " + outputPath);
            }
            Console.WriteLine("Please press enter to exit");
            string exit = Console.ReadLine();
        }
    }
}
