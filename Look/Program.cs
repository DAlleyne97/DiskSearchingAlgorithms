using System;
using System.Collections.Generic;
using System.Linq;

namespace Look
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

            Console.WriteLine("Look movement time: " + Look(head));
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

        //Look
        public static int Look(int head)
        {
            int indexOfHead;

            movementSum = 0;

            tempSchedule.AddRange(schedule);

            //adding the head to the list, then sorting and setting index of head
            tempSchedule.Add(head);
            tempSchedule.Sort();
            indexOfHead = tempSchedule.IndexOf(head);

            Console.Write("New Disk Schedule: ");

            foreach (var i in tempSchedule)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //while the index isnt at the limit (first element)
            while (indexOfHead != 0)
            {
                Console.WriteLine("Moving left from " + tempSchedule.ElementAt(indexOfHead) + " to " + tempSchedule.ElementAt(indexOfHead - 1) +
                    " is " + Math.Abs(tempSchedule.ElementAt(indexOfHead) - tempSchedule.ElementAt(indexOfHead - 1)) + " movements.");

                //summing the differences of the head toward the lower limit(first element), removing the head each time
                movementSum += Math.Abs(tempSchedule.ElementAt(indexOfHead) - tempSchedule.ElementAt(indexOfHead - 1));

                Console.WriteLine("Current movement sum: " + movementSum);
                Console.WriteLine();

                tempSchedule.RemoveAt(indexOfHead);
                indexOfHead--;
            }
            //while the list has more than one element
            while (tempSchedule.Count != 1)
            {
                Console.WriteLine("Moving right from " + tempSchedule.First() + " to " + tempSchedule.ElementAt(1) +
                    " is " + Math.Abs(tempSchedule.First() - tempSchedule.ElementAt(1)) + " movements.");
                //summing the differences of the head toward the last element 
                movementSum += Math.Abs(tempSchedule.First() - tempSchedule.ElementAt(1));

                Console.WriteLine("Current movement sum: " + movementSum);
                Console.WriteLine();

                tempSchedule.RemoveAt(0);
            }

            //clearing the list for further use
            tempSchedule.Clear();
            return movementSum;
        }

    }
}
