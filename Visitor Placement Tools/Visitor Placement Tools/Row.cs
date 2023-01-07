using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools.Enums;

namespace Visitor_Placement_Tools
{
    public class Row
    {
        public int Number { get; private set; }
        public List<Seat> Seats { get; private set; }

        public static int seats;

        public SectionLetterEnum.SectionLetter SectionLetter { get; private set; }
        public Row(int number, SectionLetterEnum.SectionLetter sectionletter)
        {
            Number = number;
            Seats = new List<Seat>();
            if(number == 1)
            {
                Random r = new Random();
               seats = r.Next(3, 10);
            }        
            GenerateSeats(seats);
        }
        public List<Seat> GenerateSeats(int amount)
        {
            for (int i = 1; i < amount; i++)
            {
                Seat seat = new Seat(i,SectionLetter,Number);
                Seats.Add(seat);
            }
            return Seats;
        }
    }
}
