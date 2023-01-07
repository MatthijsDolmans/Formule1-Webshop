using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Visitor_Placement_Tools
{
    public class Event
    {
        public DateTime StartDate { get; private set; }
        public int MaxVisitors { get; private set; }
        public List<Section> Sections { get; private set; }
        public List<Group> Groups { get; private set; }

        public Event(DateTime startDate, int maxVisitors)
        {
            StartDate = startDate;
            MaxVisitors = maxVisitors;
            Sections = new List<Section>();
            Groups = new List<Group>();
        }

        public void placeGroups(Group group)
        {
            List<Visitor> templistwithchildrenand1elder = new List<Visitor>();
            Visitor elder = new Visitor();
            foreach (var item in group.Visitors)
            {
                if (item.CheckAgeIsAbove12(StartDate) == false)
                {
                    templistwithchildrenand1elder.Add(item);
                }
                else
                {
                    elder = item;
                }
            }
            if (elder.Name != null)
            {
                templistwithchildrenand1elder.Add(elder);
                placeChildrenWith1Elder(templistwithchildrenand1elder);
            }
            else
            {
                //exception geen elder in groep
            }

        }

        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
        public void placeChildrenWith1Elder(List<Visitor> visitor)
        {

            foreach (var sections in Sections)
            {
                foreach (var rows in sections.Rows)
                {
                    if (rows.Number == 1)
                    {
                        foreach (var seats in rows.Seats)
                        {
                            foreach (var item in visitor)
                            {
                                seats.PlaceVisitor(item);
                                visitor.Remove(item);
                                break;
                            }
                        }
                    }


                }

            }

        }
    }
}
