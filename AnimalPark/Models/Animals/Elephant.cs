using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Models.AnimalPark;
using AnimalPark.Models.Poops;

namespace AnimalPark.Models.Animals
{
    class Elephant : Animal
    {
        public Elephant()
        {
        }

        public Elephant(string name) : base(name)
        {
            Name = name;
            PoopFrequency = 80;
        }

        public override Poop Poop()
        {
            return new ElephantPoop();
        }
    }
}
