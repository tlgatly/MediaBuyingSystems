using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover.Entity
{
    public class Rover : Coordinate
    {
        public Rover(int r, int c)
        {
            Row = r;
            Column = c;
        }
    }
}
