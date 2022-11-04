
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CircusTrein_ConsoleApp.Animal;
using static System.Formats.Asn1.AsnWriter;

namespace CircusTrein_ConsoleApp
{
    public class Wagon
    {
        public List<Animal> AnimalsInWagon { get; private set; }
        public int wagonNumber { get; private set; }

        private static int wagonCounter = 1;

        public Wagon()
        {
            wagonNumber = wagonCounter;
            wagonCounter++;
            AnimalsInWagon = new List<Animal>();
        }


        public bool CheckIfAnimalFits(Animal a)
        {
            int usedcapacity = 0;
            foreach (var animal in AnimalsInWagon)
            {
                usedcapacity = usedcapacity + (int)animal.GetSize();
            }
            if ((int)a.GetSize() + usedcapacity > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
