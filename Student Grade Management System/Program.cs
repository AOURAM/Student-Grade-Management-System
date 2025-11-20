using System;

namespace StudentGradeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays to store up to 100 students and their grades
            string[] students = new string[100];
            double[] grades = new double[100];
            int count = 0; // Number of students entered
            bool running = true; // Controls the main loop

            while (running)
            {
                // Display main menu
                Console.WriteLine("===== Student Grade Management System =====");
                Console.WriteLine("1. Add Student Grades");
                Console.WriteLine("2. Display All Student Grades");
                Console.WriteLine("3. Calculate Class Average Score");
                Console.WriteLine("4. Find Highest and Lowest Scores");
                Console.WriteLine("5. View Grade Distribution");
                Console.WriteLine("6. Exit Program");
                Console.Write("Please select a function (1-6): ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Add Student Grades
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();

                        double grade;
                        // Input validation for grade range 0-100
                        while (true)
                        {
                            Console.Write("Enter student grade (0-100): ");
                            if (double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                                break;
                            else
                                Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                        }

                        students[count] = name;
                        grades[count] = grade;
                        count++;
                        Console.WriteLine("Student grade added successfully!\n");
                        break;

                    case "2":
                        // Display all student grades
                        if (count == 0)
                        {
                            Console.WriteLine("No student records found.\n");
                        }
                        else
                        {
                            Console.WriteLine("===== All Student Grades =====");
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {students[i]} - {grades[i]}");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        // Calculate class average
                        if (count == 0)
                        {
                            Console.WriteLine("No grades available to calculate average.\n");
                        }
                        else
                        {
                            double total = 0;
                            for (int i = 0; i < count; i++)
                                total += grades[i];
                            double average = total / count;
                            Console.WriteLine($"Class average score: {average:F2}\n");
                        }
                        break;

                    case "4":
                        // Find highest and lowest scores
                        if (count == 0)
                        {
                            Console.WriteLine("No grades available to analyze.\n");
                        }
                        else
                        {
                            double max = grades[0], min = grades[0];
                            string maxStudent = students[0], minStudent = students[0];

                            for (int i = 1; i < count; i++)
                            {
                                if (grades[i] > max)
                                {
                                    max = grades[i];
                                    maxStudent = students[i];
                                }
                                if (grades[i] < min)
                                {
                                    min = grades[i];
                                    minStudent = students[i];
                                }
                            }

                            Console.WriteLine($"Highest Score: {maxStudent} - {max}");
                            Console.WriteLine($"Lowest Score: {minStudent} - {min}\n");
                        }
                        break;

                    case "5":
                        // Grade distribution
                        if (count == 0)
                        {
                            Console.WriteLine("No grades available for distribution.\n");
                        }
                        else
                        {
                            int A = 0, B = 0, C = 0, D = 0, E = 0;

                            for (int i = 0; i < count; i++)
                            {
                                if (grades[i] >= 90) A++;
                                else if (grades[i] >= 80) B++;
                                else if (grades[i] >= 70) C++;
                                else if (grades[i] >= 60) D++;
                                else E++;
                            }

                            Console.WriteLine("===== Grade Distribution =====");
                            Console.WriteLine($"A (90-100): {A}");
                            Console.WriteLine($"B (80-89): {B}");
                            Console.WriteLine($"C (70-79): {C}");
                            Console.WriteLine($"D (60-69): {D}");
                            Console.WriteLine($"E (0-59):  {E}\n");
                        }
                        break;

                    case "6":
                        // Exit program
                        running = false;
                        Console.WriteLine("Thank you for using. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again!\n");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
