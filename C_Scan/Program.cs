using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Scan
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
            foreach (var i in schedule)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Starting position: " + head);
            Console.WriteLine();

            Console.WriteLine("C_Scan movement time: " + C_Scan(head));
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

        //C-Scan
        public static int C_Scan(int head)
        {
            int indexOfHead;

            //making a temporary list to preserve original list
            tempSchedule.AddRange(schedule);

            //resetting movement sum in case another function was already called
            movementSum = 0;

            //adding the head and the upper limit of 4999 to the list, then sorting 
            tempSchedule.Add(head);
            tempSchedule.Add(4999);

            //SORTING THE LIST
            tempSchedule.Sort();

            Console.Write("New Disk Schedule: ");

            foreach (var i in tempSchedule)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //setting the head index
            indexOfHead = tempSchedule.IndexOf(head);

            //while the head value doesnt match the last
            while (tempSchedule.ElementAt(indexOfHead) != tempSchedule.Last())
            {
                Console.WriteLine("Moving right from " + tempSchedule.ElementAt(indexOfHead) + " to " + tempSchedule.ElementAt(indexOfHead + 1) +
                    " is " + Math.Abs(tempSchedule.ElementAt(indexOfHead) - tempSchedule.ElementAt(indexOfHead + 1)) + " movements.");

                //summing the differences of the head toward the upper limit of 4999, removing the head each time
                movementSum += Math.Abs(tempSchedule.ElementAt(indexOfHead) - tempSchedule.ElementAt(indexOfHead + 1));

                Console.WriteLine("Current movement sum: " + movementSum);
                Console.WriteLine();

                tempSchedule.RemoveAt(indexOfHead);
            }

            //while the list has more than one element
            while (tempSchedule.Count != 1)
            {
                Console.WriteLine("Moving left from " + tempSchedule.Last() + " to " + tempSchedule.ElementAt(tempSchedule.Count() - 2) +
                    " is " + Math.Abs(tempSchedule.Last() - tempSchedule.ElementAt(tempSchedule.Count() - 2)) + " movements.");

                //summing the differences of the head and the previous toward the first element, then remove the head
                movementSum += Math.Abs(tempSchedule.Last() - tempSchedule.ElementAt(tempSchedule.Count() - 2));

                Console.WriteLine("Current movement sum: " + movementSum);
                Console.WriteLine();

                tempSchedule.RemoveAt(tempSchedule.IndexOf(tempSchedule.Last()));
            }

            //clearing the list for further use
            tempSchedule.Clear();
            return movementSum;
        }
    }
}
