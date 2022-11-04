using CircusTrein_ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCircustrein
{
    public class WagonTest
    {
        [TestMethod]
        public void ErrorWhenToMuchCapacity()
        {
            Animal animal1 = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
            Animal animal2 = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
            Animal animal3 = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
            Wagon wagon = new Wagon();
            wagon.AnimalsInWagon.Add(animal1);
            wagon.AnimalsInWagon.Add(animal2);

            Assert.AreEqual(false, wagon.CheckIfAnimalFits(animal3));
        }
    }
}
