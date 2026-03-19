

using System;

namespace AttendanceTracker

{
    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Welcome to the Classroom Attendance Tracker!");

            // Step 1: Ask how many students
            Console.Write("Enter the number of students: ");

            int numStudents;
            string input = (Console.ReadLine());


            // make a while loop with TryParse() to ensure the numStudents is a 
            // int and not 0 or negative
            while (!int.TryParse(input, out numStudents) || numStudents <= 0)
            {
                Console.WriteLine("Invalid number of students, please enter a number greater than 0.");
                Console.WriteLine("Enter the number of students: ");
                input = Console.ReadLine();
            }

            
                // Step 2: Create array for student names, this already done for me
                // there are 2 arrays in this code, this one just stores student names

                string[] studentNames = new string[numStudents];



            // TODO: Fill in a loop to get each student's name

            for (int i = 0; i < numStudents; i++)

            {

                Console.Write($"Enter name for student #{i + 1}: ");

                studentNames[i] = Console.ReadLine();

            }

            // Step 3: Create 2D array for attendance (rows = students, columns = 5 days)
            // this was already done for me
            // this is the 2nd array, this one stores the 1 or 0 for attendance
            // and the day number


            int[,] attendance = new int[numStudents, 5];
              
            // make a for loop that will run the numStudents times
            // inside that for loop make another for loop that will run 5 times
            // asker user input Y or N, convert Y and N into 1 and 0 and store in 
            // attendance array, example: if a student were present on day 3 the array will
            // say attendance[1, 2], 1 for present and 2 for the 3rd day (0,1,2)
            // The if statements do the part of storing in the array
            // if Y then store a 1 in the attendance array at that position
            // i and day for that current loop

            for (int i = 0; i < numStudents; i++)

            {

                Console.WriteLine($"\nAttendance for {studentNames[i]} (Y/N):");

                for (int day = 0; day < 5; day++)

                {
                    string inputYN;
                    
                    while (true)
                    {


                        Console.Write($"Day {day + 1}?: ");
                        inputYN = (Console.ReadLine()).Trim().ToUpper();

                        if (inputYN == "Y")
                        {
                            attendance[i, day] = 1;
                            break;
                        }

                        else if (inputYN == "N")
                        {
                            attendance[i, day] = 0;
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Please enter Y or N.");
                        }

                    }

                }

            }

            // Step 4: Display results, this part alrady done

            Console.WriteLine("\n--- Attendance Summary ---");

            for (int i = 0; i < numStudents; i++)

            {

                int totalDays = 0;

                for (int day = 0; day < 5; day++)

                {

                    // totalDays is the added amount of 1s that a student is present
                    totalDays += attendance[i, day];

                }

                // average is totalDays divided by 5
                double average = (double)totalDays / 5;



                Console.WriteLine($"{studentNames[i]} attended {totalDays}/5 days (Average: {average * 100:F1}%)");

                // Optional: indicate perfect attendance or zero attendance
                // this part already done for me

                if (totalDays == 5)

                    Console.WriteLine(" -> Perfect Attendance!");

                else if (totalDays == 0)

                    Console.WriteLine(" -> Needs Improvement!");

            }


            // Make an attendance chart
            // top line
            Console.WriteLine("\n--- Attendance Chart ---");

            // Name then a tab
            Console.Write("Name\t");

            // for loop that runs 5 times
            // displays day # then tabs 5 times
            for (int day = 0; day < 5; day++)
            {
                Console.Write($"Day {day + 1}\t");
            }

            // skip a line
            Console.WriteLine();

            // line of ----
            Console.WriteLine("-----------------------------------------------");

            // for loop will run for each student
            // 1st printing studentsNames[i] and tab then 
            // run another for loop 5 times that prints a * tab or - tab is student is present
            // after the inner for loop it will drop down a line and do it again
            for (int i = 0; i< numStudents; i++)
            {
                Console.Write($"{studentNames[i]}\t");

                for (int day = 0; day < 5; day++)
                {
                    if (attendance[i, day] == 1)
                    {
                        Console.Write("*\t");
                    }
                    else
                    {
                        Console.Write("-\t");
                    }
                }
                // skip to new line
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to exit...");

            Console.ReadKey();

        }

    }

}

