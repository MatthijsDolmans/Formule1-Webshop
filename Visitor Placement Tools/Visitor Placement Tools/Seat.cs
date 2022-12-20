using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools.Enums;

namespace Visitor_Placement_Tools
{
    public class Seat
    {
        public int Number { get; private set; }
        public string SeatName { get; private set; }
        public Visitor SeatedVisitor { get; private set; }
        public Seat(int number, SectionLetterEnum.SectionLetter sectionLetter, int row)
        {
            Number = number;
            SeatName = sectionLetter + "-" + row + "-" + Number;
        }
        public void PlaceVisitor(Visitor visitor)
        {
            SeatedVisitor = visitor;
        }
    }
}
