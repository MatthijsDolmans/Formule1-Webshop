
using ConsoleAppCircusTrein;
using static ConsoleAppCircusTrein.Animal;
using static System.Formats.Asn1.AsnWriter;

Animal animal1 = new Animal(AnimalType.Carnivore, AnimalSize.Small);
Animal animal2 = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
Animal animal3 = new Animal(AnimalType.Carnivore, AnimalSize.Medium);
Animal animal4 = new Animal(AnimalType.Herbivore, AnimalSize.Large);
Animal animal5 = new Animal(AnimalType.Herbivore, AnimalSize.Large);
Animal animal6 = new Animal(AnimalType.Herbivore, AnimalSize.Large);
Animal animal7 = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
Animal animal8 = new Animal(AnimalType.Carnivore, AnimalSize.Large);
Animal animal9 = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
Animal animal10 = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
Animal animal11 = new Animal(AnimalType.Herbivore, AnimalSize.Medium);


List<Animal> animals = new List<Animal>();
animals.Add(animal1);
animals.Add(animal2);
animals.Add(animal3);
animals.Add(animal4);
animals.Add(animal5);
animals.Add(animal6);
animals.Add(animal7);
animals.Add(animal8);
animals.Add(animal9);
animals.Add(animal10);
animals.Add(animal11);

Train Train = new Train();
var sortedwagons = Train.SortAnimalsIntoWagons(animals);

foreach (var wagon in sortedwagons)
{
    Console.WriteLine("CoupeNr: " + wagon.wagonNumber.ToString());
    foreach (var animal in wagon.AnimalsInWagon)
    {
        Console.WriteLine(animal.ToString());
    }
}

        
