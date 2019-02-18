using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.Poops
{
    abstract class Poop
    {
        public byte Smell { get; set; }
        public int CleanTime { get; set; }
    }
}
