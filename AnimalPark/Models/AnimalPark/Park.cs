using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimalPark.Models.AnimalPark
{
    class Park
    {
        public Park()
        {
            AverageReview = 0;
            OverallPoopAmount = 0;
            AnimalCages = new List<Cage>();
            GuestList = new List<Guest>();
            ListofReviews = new List<byte>();
        }
        //Checks if Park is currently Open
        public bool ParkIsOpen { get; set; }
        //A List of all the Cages with animals in the park
        public List<Cage> AnimalCages { get; private set; }
        //A list of all the guests visiting the park
        public List<Guest> GuestList { get; private set; }
        //A list of all the reviews left by the visitors
        public List<byte> ListofReviews { get; private set; }
        //A list of all the workers at the park
        public List<ZooWorker> ZooWorkers { get; set; }
        //The Average review of the park
        public byte AverageReview { get; private set; }
        //The overall amount of poop at the park
        public int OverallPoopAmount { get; set; }

        //Gather review from Visitor
        public void GatherReview(byte reviewScore)
        {
            ListofReviews.Add(reviewScore);
        }

        //Calculates the Average Review from the List Of Reviews
        public int CalculateAverageReview()
        {
            if (ListofReviews.Count > 0)
            {
                int total = 0;
                foreach (byte b in ListofReviews)
                {
                    total += b;
                }
                return (total / ListofReviews.Count);
            }
            return 0;
        }

        //Returns the highest Review
        public byte GetHighestReview()
        {
            return ListofReviews.Max();
        }

        //Returns the Lowest Review
        public byte GetLowestReview()
        {
            return ListofReviews.Min();
        }

        //Calculates the amount of poop across the entire park
        public void CalculatePoopAmount()
        {
            int totalAmount = 0;
            for (int i = 0; i < AnimalCages.Count; i++)
            {
                totalAmount += AnimalCages[i].PoopAmount.Count;
            }
            OverallPoopAmount = totalAmount;
        }

        //Closes park and gets reviews from guests
        public void ClosePark()
        {
            foreach (Guest guest in GuestList)
            {
                guest.LeavePark(this);
            }
        }

        //Opens park allowing people to come visit
        //Async to allow them to join a little at a time
        public async void OpenPark()
        {
            ParkIsOpen = true;
            for (int i = 0; i < 100; i++)
            {
                GuestList.Add(new Guest(this));
                await Task.Delay(1);
            }
        }

        //Async Method to make all the park function
        //Make the animals start pooping
        //Make the workers start working
        public async void RunPark()
        {
            foreach (Cage cage in AnimalCages)
                cage.Run();

            foreach (ZooWorker worker in ZooWorkers)
                foreach (Cage cage in AnimalCages)
                    worker.CleanCage(cage);

            while (Program.running)
            {
                if (Time.CurrentTime > 10 && Time.CurrentTime < 20 && !ParkIsOpen)
                {
                    OpenPark();
                }
                else if (Time.CurrentTime < 10 && Time.CurrentTime > 20 && ParkIsOpen)
                {
                    if (GuestList.Count > 0)
                        ClosePark();
                }
                await Task.Delay(TimeSpan.FromMinutes(5));
            }
        }
    }
}
