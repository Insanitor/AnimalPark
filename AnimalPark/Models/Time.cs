using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models
{
    class Time
    {
        public static int CurrentTime { get; set; }

        public async void TimePasses()
        {
            while (Program.running)
            {
                CurrentTime = 0;
                await Task.Delay(TimeSpan.FromSeconds(5));
                if (CurrentTime != 24)
                    CurrentTime++;
                else
                    CurrentTime = 0;
            }
        }
    }
}
