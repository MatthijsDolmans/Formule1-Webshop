using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools
{
    public class Visitor
    {
        public DateTime DateOfBirth { get; private set; }
        public DateTime DateSignedUp { get; private set; }
        public int VisitorId { get; private set; }
        public string Name { get; private set; }
        public bool Ischild { get; private set; }

        private static int LastVisitorId = 0;

        public Visitor(DateTime dateOfBirth, string name)
        {
            DateOfBirth = dateOfBirth;
            DateSignedUp = DateTime.Now;
            Name = name;
            VisitorId = NextId();
        }
        public int NextId()
        {
            LastVisitorId++;
            return LastVisitorId;
        }

        public void CheckAge()
        {
            
        }
    }
}
