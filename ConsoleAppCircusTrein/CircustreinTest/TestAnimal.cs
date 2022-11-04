using ConsoleAppCircusTrein;

namespace CircustreinTest

{
    [TestClass]
    public class TestAnimal
    {
        [TestMethod]
        public void CreateAnimalSize()
        {
            Animal animal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);

            Assert.AreEqual(3, (int)animal.GetSize());
        }
        [TestMethod]
        public void TestAnimalEatingEachother()
        {
            Animal animal1 = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon();
            wagon.AnimalsInWagon.Add(animal1);

            Assert.AreEqual(false, animal1.CheckIfAnimalCanEat(wagon));
        }
    }
}