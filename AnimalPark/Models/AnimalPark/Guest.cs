using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Models.AnimalPark
{
    class Guest
    {
        public Guest(Park park)
        {
            Happiness = byte.Parse((new Random().Next(50, 150) + 1).ToString());
            EnjoyPark(park);
        }

        public byte Happiness { get; set; }

        public byte LeaveReview()
        {
            return Happiness;
        }

        public async void EnjoyPark(Park park)
        {
            if (park.OverallPoopAmount > 10)
                Happiness--;
            else if (park.OverallPoopAmount > 20)
            {
                if (Happiness <= 3)
                    Happiness = 0;
                Happiness -= 3;
            }
            else
                Happiness++;
            if (Happiness <= 0)
                LeavePark(park);
            await Task.Delay(TimeSpan.FromSeconds(3));
        }

        public void LeavePark(Park park)
        {
            park.GatherReview(LeaveReview());
            park.GuestList.Remove(this);
        }
    }
}
