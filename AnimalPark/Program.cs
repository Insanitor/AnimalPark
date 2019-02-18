using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Models;
using AnimalPark.Models.AnimalPark;
using AnimalPark.Models.Animals;

namespace AnimalPark
{
    class Program
    {
        public static bool running = true;
        static void Main(string[] args)
        {
            Time t = new Time();
            t.TimePasses();

            Park ZoologiskHave = new Park();
            ZooWorker Bob = new ZooWorker();
            ZooWorker Lars = new ZooWorker();

            Cage ElephantCage = new Cage(6);
            for (int i = 0; i < 6; i++)
            {
                ElephantCage.AddAnimalToPen(new Elephant());
            }
            ZoologiskHave.AnimalCages.Add(ElephantCage);

            //Bleeds alot of Memory, reason unknown
            Task task = new Task(ZoologiskHave.RunPark);
            task.Start();
            Console.ReadKey();
            ZoologiskHave.ClosePark();
            Console.WriteLine(ZoologiskHave.CalculateAverageReview());
            Console.ReadKey();

        }
    }
}
