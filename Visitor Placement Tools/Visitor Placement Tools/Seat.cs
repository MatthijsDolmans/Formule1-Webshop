using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools
{
    public class Seat
    {
        public int Number { get; private set; }
        public bool IsOccupied { get; private set; }
        public Visitor SeatedVisitor { get; private set; }
        public Seat(int number)
        {
            Number = number;
            IsOccupied = false;
        }
        public void PlaceVisitor()
        {

        }
    }
}
