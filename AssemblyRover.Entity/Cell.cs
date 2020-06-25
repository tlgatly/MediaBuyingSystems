using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover.Entity
{
    public class Cell : Coordinate
    {
        public bool IsVisited { get; set; }
        public bool HasComponent { get; set; }
        public HashSet<int> Components { get; set; }

        public Cell()
        {
            IsVisited = false;
            HasComponent = false;
            Components = new HashSet<int>();
        }
    }
}
