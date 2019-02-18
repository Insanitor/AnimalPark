using AnimalPark.Models.Poops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.Poops
{
    class ElephantPoop : Poop
    {
        public ElephantPoop()
        {
            CleanTime = 80;
        }
    }
}
