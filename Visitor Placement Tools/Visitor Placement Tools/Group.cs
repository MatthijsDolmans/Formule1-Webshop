using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools
{
    public class Group
    {
        public List<Visitor> Visitors{ get; private set; }
        public int GroupId { get; private set; }

        private static int id;

        public Group(List<Visitor> visitorsingroup)
        {
            Visitors = visitorsingroup;
            id++;
            GroupId = id;
        }
    }
}
