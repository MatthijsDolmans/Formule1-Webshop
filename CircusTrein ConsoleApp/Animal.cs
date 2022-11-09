using CircusTrein_ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein_ConsoleApp
{
    public class Animal
    {
        public enum AnimalType { Carnivore, Herbivore }

        public enum AnimalSize { Small = 1, Medium = 3, Large = 5 }
        private AnimalType Type { get; set; }

        private AnimalSize Size { get; set; }

        public Animal(AnimalType type, AnimalSize size)
        {
            Type = type;
            Size = size;
        }
        public bool CheckIfAnimalCanEat(Wagon wagon)
        {
            foreach (var animal in wagon.AnimalsInWagon)
            {
                if (Type == AnimalType.Carnivore)
                {
                    if (animal.Type == AnimalType.Herbivore)
                    {
                        if ((int)Size < (int)animal.Size)
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
                else if (Type == AnimalType.Herbivore)
                {
                    if (animal.Type == AnimalType.Carnivore)
                    {
                        if ((int)Size > (int)animal.Size)
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
            return true;
        }
        public override string ToString()
        {
            string s = "Animal: " + Type.ToString() + ", " + Size.ToString();
            return s;
        }
        public AnimalSize GetSize()
        {
            return Size;
        }
        public AnimalType GetType()
        {
            return Type;
        }

    }
}
