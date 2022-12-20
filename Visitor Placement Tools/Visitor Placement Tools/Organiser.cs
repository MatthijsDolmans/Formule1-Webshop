using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools
{
    public class Organiser
    {
        public List<Event> Events { get; private set; }
        public List<Visitor> RegisteredVisitors { get; private set; }

        public Organiser()
        {
            Events = new List<Event>();
            RegisteredVisitors = new List<Visitor>();
        }

        public void CreateEvent(DateTime StartDate,int MaxVisitors)
        {
            Event NewEvent = new Event(StartDate, MaxVisitors);
            Events.Add(NewEvent);
           
        }
        public void Placeintogroups(Group group)
        {
            foreach(var item in Events)
            {
                item.placeGroups(group);
            }
        }
    }
}
