using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Look
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

            Console.WriteLine("C_Look movement time: " + C_Look(head));
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

        //C_Look
        public static int C_Look(int head)
        {
            int indexOfHead;

            movementSum = 0;

            tempSchedule.AddRange(schedule);

            //adding the head,sorting, and setting the index of the head
            tempSchedule.Add(head);
            tempSchedule.Sort();
            indexOfHead = tempSchedule.IndexOf(head);

            //while the head isnt the last value int the list
            while (tempSchedule.ElementAt(indexOfHead) != tempSchedule.Last())
            {
                Console.WriteLine("Moving right from " + tempSchedule.ElementAt(indexOfHead) + " to " + tempSchedule.ElementAt(indexOfHead + 1) +
                   " is " + Math.Abs(tempSchedule.ElementAt(indexOfHead) - tempSchedule.ElementAt(indexOfHead + 1)) + " movements.");

                //summing the differences of the head toward the upper limit(last element), removing the head each time
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

                //summing the differences of the head toward the first element 
                movementSum += Math.Abs(tempSchedule.Last() - tempSchedule.ElementAt(tempSchedule.IndexOf(tempSchedule.Last()) - 1));

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
