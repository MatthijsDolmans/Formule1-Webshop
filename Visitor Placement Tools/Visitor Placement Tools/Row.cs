using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools
{
    public class Row
    {
        public int Number { get; private set; }
        public List<Seat> Seats { get; private set; }
        public Row(int number)
        {
            Number = number;
            Seats = new List<Seat>();
        }
    }
}
