using AnimalPark.Models.Animals;
using AnimalPark.Models.Poops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.AnimalPark
{
    class Cage
    {
        public Cage(int cageSize)
        {
            CageSize = cageSize;
            AnimalCage = new Animal[CageSize];
            PoopAmount = new Stack<Poop>();
        }

        public int CageSize { get; set; }
        public Animal[] AnimalCage { get; set; }
        public Stack<Poop> PoopAmount { get; set; }

        public void AddAnimalToPen(Animal animal)
        {
            for (int i = 0; i < AnimalCage.Length - 1; i++)
            {
                if (AnimalCage[i] == null)
                {
                    AnimalCage[i] = animal;
                    break;
                }
            }
        }

        public void RemoveAnimalFromPen(int index)
        {
            if (AnimalCage[index] != null)
                AnimalCage[index] = null;
        }

        public async void Run()
        {
            while (Program.running)
            {
                int poopDelay = 0;
                for (int i = 0; i < AnimalCage.Length - 1; i++)
                {
                    if (AnimalCage[i] != null)
                    {
                        if (poopDelay == 0)
                            poopDelay = AnimalCage[i].PoopFrequency;
                        PoopAmount.Push(AnimalCage[i].Poop());
                    }
                }
                await Task.Delay(poopDelay);
            }
        }
    }
}
