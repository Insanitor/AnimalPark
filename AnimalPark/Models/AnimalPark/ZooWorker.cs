using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.AnimalPark
{
    class ZooWorker
    {
        public string Name { get; set; }
        public async void CleanCage(Cage cage)
        {
            while (cage.PoopAmount.Count > 0 && (Time.CurrentTime > 10 && Time.CurrentTime < 20))
            {
                await Task.Delay(cage.PoopAmount.First().CleanTime);
                cage.PoopAmount.Pop();
            }
        }
    }
}
