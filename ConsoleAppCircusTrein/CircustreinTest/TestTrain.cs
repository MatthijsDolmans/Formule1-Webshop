using ConsoleAppCircusTrein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircustreinTest
{
  
    [TestClass]
    public class TestTrain
    {
        [TestMethod]
        public void TestAddingAnimal()
        {
            Animal animal1 = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
            Animal animal2 = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon();
            Train train = new Train();
            wagon.AnimalsInWagon.Add(animal1);

            Assert.AreEqual(true, train.CanAnimalBeAdded(animal2, wagon));
        }

    }
}
