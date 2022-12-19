using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Visitor_Placement_Tools.Enums.SectionLetterEnum;

namespace Visitor_Placement_Tools
{
    public class Section
    {
        public SectionLetter Name { get; private set; }
        public List<Row> Rows { get; private set; }
        public Section(SectionLetter name)
        {
            Name = name;
            Rows = new List<Row>();
        }
    }
}
