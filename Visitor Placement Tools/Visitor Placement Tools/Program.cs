
using Visitor_Placement_Tools;

int maxcap = 25;

Organiser organiser = new Organiser();
List<Visitor> totalvisitors = new List<Visitor>();
List<Visitor> templist = new List<Visitor>();
Random r = new Random();


organiser.CreateEvent(DateTime.Now, maxcap);

for (int i = 0; i < maxcap; i++)
{
    
    int Year = r.Next(1900, 2022);
    int Month = r.Next(1,12);
    int Day = r.Next(1, 29);

    totalvisitors.Add(new Visitor(new DateTime(Year, Month, Day), "matthijs" + i));

    //Console.WriteLine(totalvisitors[i].DateOfBirth.ToString("dd/MM/yyyy")+" "+ totalvisitors[i].Name + " "+ totalvisitors[i].VisitorId);
}
for (int i = 0; i < 5; i++)
{
    templist.Add(totalvisitors[0]);
    totalvisitors.RemoveAt(0);
    
}
Group group1 = new Group(templist);
Group group2 = new Group(templist);
Group group3 = new Group(templist);
Group group4 = new Group(templist);
Group group5 = new Group(templist);

