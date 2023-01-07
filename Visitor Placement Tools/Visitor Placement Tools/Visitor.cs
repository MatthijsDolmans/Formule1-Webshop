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
        public Visitor()
        {

        }
        public int NextId()
        {
            LastVisitorId++;
            return LastVisitorId;
        }

        public bool CheckAgeIsAbove12( DateTime eventdate)
        {
          int yearage = eventdate.Year - DateOfBirth.Year;
          int monthage = eventdate.Month - DateOfBirth.Month;
          int dayage = eventdate.Day - DateOfBirth.Day;
            
            if(yearage >= 12)
            {              
                return true;
            }
            else if(yearage == 11)
            {
                if (monthage > 0)
                {
                    return true;
                }
                else if (monthage == 0 && dayage >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
