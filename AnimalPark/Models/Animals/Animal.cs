using AnimalPark.Interfaces;
using AnimalPark.Models.AnimalPark;
using AnimalPark.Models.Poops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.Animals
{
    abstract class Animal : IPoop
    {
        protected Animal()
        {
        }

        protected Animal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int PoopFrequency { get; set; }

        public abstract Poop Poop();
    }
}
