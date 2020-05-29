using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestSeekTimeFirst
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

            Console.WriteLine("Shortest Seek Time First movement time: " + SsTf(head));
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

        //Shortest seek time first
        public static int SsTf(int head)
        {
            int temp;
            int indexOfHead;
            int left;
            int right;

            //making a temporary list to preserve original list
            tempSchedule.AddRange(schedule);

            //resetting movement sum in case another function was already called
            movementSum = 0;

            //Adding the head and sorting the list
            tempSchedule.Add(head);
            tempSchedule.Sort();

            Console.Write("New Disk Schedule: ");

            foreach (var i in tempSchedule)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //keeping track of the index of the head, left/right of head 
            indexOfHead = tempSchedule.IndexOf(head);
            left = indexOfHead - 1;
            right = indexOfHead + 1;

            while (tempSchedule.Count() != 1)
            {
                //checking to see if the head is the first element 
                if (tempSchedule.IndexOf(head) == 0)
                {
                    Console.WriteLine("Moving right from " + head + " to " + tempSchedule.ElementAt(1) +
                    " is " + Math.Abs((head - tempSchedule.ElementAt(1))) + " movements.");

                    //getting the difference of the head(first element) and the next element 
                    movementSum += Math.Abs(head - tempSchedule.ElementAt(1));

                    Console.WriteLine("Current movement sum: " + movementSum);
                    Console.WriteLine();

                    //removing the first element 
                    tempSchedule.Remove(head);

                    //making the new first element the head
                    head = tempSchedule.ElementAt(0);
                }
                //checking to see if the head is the last element 
                else if (tempSchedule.IndexOf(head) == tempSchedule.IndexOf(tempSchedule.Last()))
                {
                    Console.WriteLine("Moving left from " + head + " to " + tempSchedule.ElementAt(tempSchedule.Count() - 2) +
                    " is " + Math.Abs((head - tempSchedule.ElementAt(tempSchedule.Count() - 2))) + " movements.");

                    //getting the difference of the head(last element) and the previous element
                    movementSum += Math.Abs(head - tempSchedule.ElementAt(tempSchedule.Count() - 2));

                    Console.WriteLine("Current movement sum: " + movementSum);
                    Console.WriteLine();

                    //removing the head(last elememt) and making the new last the head
                    tempSchedule.Remove(head);
                    head = tempSchedule.ElementAt(tempSchedule.IndexOf(tempSchedule.Last()));
                }
                //checking to see if the left differecne is smaller or equal than the right
                else if (Math.Abs(head - tempSchedule.ElementAt(left)) <= Math.Abs(head - tempSchedule.ElementAt(right)))
                {
                    Console.WriteLine("Moving left from " + head + " to " + tempSchedule.ElementAt(left) +
                    " is " + Math.Abs((head - tempSchedule.ElementAt(left))) + " movements.");

                    //adds the left differece to the sum
                    movementSum += Math.Abs(head - tempSchedule.ElementAt(left));

                    Console.WriteLine("Current movement sum: " + movementSum);
                    Console.WriteLine();

                    //holding the left value, removing the head and making the left value the head
                    temp = tempSchedule.ElementAt(left);
                    tempSchedule.Remove(head);
                    head = temp;

                    //updating the head's index and values of left and right
                    indexOfHead = tempSchedule.IndexOf(head);
                    left = indexOfHead - 1;
                    right = indexOfHead + 1;

                }
                //checking to see if the right differecne is smaller than the left
                else if (Math.Abs(head - tempSchedule.ElementAt(right)) < Math.Abs(head - tempSchedule.ElementAt(left)))
                {
                    Console.WriteLine("Moving right from " + head + " to " + tempSchedule.ElementAt(right) +
                   " is " + Math.Abs((head - tempSchedule.ElementAt(right))) + " movements.");

                    //adds the left differece to the sum
                    movementSum += Math.Abs(head - tempSchedule.ElementAt(right));

                    Console.WriteLine("Current movement sum: " + movementSum);
                    Console.WriteLine();

                    //holding the left value, removing the head and making the left value the head
                    temp = tempSchedule.ElementAt(right);
                    tempSchedule.Remove(head);
                    head = temp;

                    //updating the head's index and values of left and right
                    indexOfHead = tempSchedule.IndexOf(head);
                    left = indexOfHead - 1;
                    right = indexOfHead + 1;

                }
            }

            //clearing the list for further use
            tempSchedule.Clear();
            return movementSum;
        }



    }
}
