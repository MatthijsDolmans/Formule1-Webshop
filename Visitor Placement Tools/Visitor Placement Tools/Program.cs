
using Visitor_Placement_Tools;
using Visitor_Placement_Tools.Enums;

int maxcap = 4;
int test = 0;
Organiser organiser = new Organiser();
List<Visitor> totalvisitors = new List<Visitor>();
List<Visitor> templist = new List<Visitor>();
Visitor visitor1 = new Visitor(new DateTime(2015, 2, 22), "matthijs" + 6);
Random r = new Random();


Section section = new Section(SectionLetterEnum.SectionLetter.A, 2);
organiser.CreateEvent(DateTime.Now, maxcap);

for (int i = 0; i < maxcap; i++)
{
    
    int Year = r.Next(1900, 2022);
    int Month = r.Next(1,12);
    int Day = r.Next(1, 29);

    totalvisitors.Add(new Visitor(new DateTime(Year, Month, Day), "matthijs" + i));

    //Console.WriteLine(totalvisitors[i].DateOfBirth.ToString("dd/MM/yyyy")+" "+ totalvisitors[i].Name + " "+ totalvisitors[i].VisitorId);
}
totalvisitors.Add(visitor1);
for (int i = 0; i < 5; i++)
{
    templist.Add(totalvisitors[0]);
    totalvisitors.RemoveAt(0);   
}

Group group1 = new Group(templist);



foreach (var item in organiser.Events)
{
    item.AddSections(section);
    organiser.Placeintogroups(group1);
    foreach (var item1 in item.Sections)
    {
        Console.WriteLine("Section: " + item1.Name);
        foreach (var item2 in item1.Rows)
        {
            foreach (var item3 in item2.Seats)
            {
                Console.WriteLine("place: " + item2.Number + "-" + item3.Number);
                if (item3.SeatedVisitor != null)
                {
                    Console.WriteLine(item3.SeatedVisitor.Name + "Date of birth: " + item3.SeatedVisitor.DateOfBirth);
                }
            }
        }
    }
}


