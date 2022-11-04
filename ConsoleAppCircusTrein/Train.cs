using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleAppCircusTrein
{
    public class Train
    {
        private List<Wagon> wagons { get; set; }

        public Train()
        {
            List<Wagon> wagons = new List<Wagon>();
            this.wagons = wagons;
        }
        public IReadOnlyList<Wagon> SortAnimalsIntoWagons(List<Animal> animals)
        {
            Wagon firstwagon = new Wagon();
            wagons.Add(firstwagon);
            foreach (var animal in animals)
            {
                foreach (var wagon in wagons.ToList())
                {
                    if (CanAnimalBeAdded(animal, wagon))
                    {
                        wagon.AnimalsInWagon.Add(animal);
                        break;
                    }
                    if (wagon.wagonNumber == wagons.Count)
                    {
                        Wagon newwagon = new Wagon();
                        newwagon.AnimalsInWagon.Add(animal);
                        wagons.Add(newwagon);
                        break;
                    }
                }
            }
            return wagons.AsReadOnly();
        }
        public bool CanAnimalBeAdded(Animal animal, Wagon wagon)
        {
            if (wagon.CheckIfAnimalFits(animal) && animal.CheckIfAnimalCanEat(wagon))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
