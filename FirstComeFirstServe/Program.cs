using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstComeFirstServe
{
    class Program
    {
        public static List<int> schedule = new List<int>();
        public static List<int> tempSchedule = new List<int>();
        public static Random random = new Random();
        public static int movementSum;
        public static int head;
        public static int process;

        static void Main(string[] args)
        {
            //function call to generate list to be used in later functions
            GenerateList();

            //Function call to add head to list
            MakeHead();

            Console.Write("Disk Schedule: ");

            //Printing each element in the list
            foreach(var i in schedule)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Starting position: " + head);
            Console.WriteLine();



            Console.WriteLine("First Comes First Serve movement time: " + FcFs(head));
            Console.WriteLine();
        }

        //Function to generate list
        public static void GenerateList()
        {
            //Gives a process a random numer
            process = random.Next(1, 4998);

            //making a list of 1000 numbers
            while (schedule.Count != 10)
            {
                //check to see if element to be added is already in the list
                if (schedule.Contains(process) == false)
                {
                    schedule.Add(process);
                }
                else if (schedule.Contains(process) == true)
                {
                    process = random.Next(1, 4998);
                }
            }

        }

        //generating a head for starting position
        public static void MakeHead()
        {
            head = random.Next(1, 4998);

            //making sure the head is not in the list
            while (schedule.Contains(head) != false)
            {
                head = random.Next(1, 4998);
            }
        }

        //First come first serve function
        public static int FcFs(int head)
        {
            //making a temporary list to preserve original list
            tempSchedule.AddRange(schedule);

            //resetting movement sum in case another function was already called
            movementSum = 0;

            while (tempSchedule.Count != 0)
            {
                Console.WriteLine("Moving from " + head + " to " + tempSchedule.First() +
                    " is " + Math.Abs((head - tempSchedule.First())) + " movements.");

                //taking differnce between the head and the first value in the list
                //taking the absolute value then adding it to the sum
                movementSum += Math.Abs((head - tempSchedule.First()));

                Console.WriteLine("Current movement sum: " + movementSum);
                Console.WriteLine();

                //making the head the frist element then removing it from the list
                head = tempSchedule.First();
                tempSchedule.RemoveAt(0);

            }

            //clearing the list for further use
            tempSchedule.Clear();
            return movementSum;
        }
    }
}
