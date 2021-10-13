using System;
using System.Collections.Generic;

namespace Primtal
{
    // Everything that is displayed in the console can be found in this class.
    public class View
    {
        // This method is where everything is put together.
        public static void Menu()
        {
            var primeController = new Controllers.PrimeController();
            var view = new View();
            var prime = new Prime();
            prime.primeList = new List<int>();

            Console.SetWindowSize(50, 25);
            Console.Clear();

            bool menuLoop = true;
            while (menuLoop)
            {
                view.PrintMenu();
                Console.Write("                        ");
                string input = Console.ReadLine();

                // This option lets the user add a prime by input.
                if (input == "1")
                {
                    int primeInt = primeController.AcceptableInput();

                    if (primeController.AddPrime(primeInt))
                    {
                        view.PrintMenu();
                        prime.primeList.Add(primeInt);
                        Console.WriteLine($"{primeInt} has been added to the data structure.");
                        Console.ReadLine();
                    }
                    else if (primeController.AddPrime(primeInt) == false)
                    {
                        view.PrintMenu();
                        Console.WriteLine($"{primeInt} is not a prime number!");
                        Console.ReadLine();
                    }
                }

                // This option adds the next prime to the data structure.
                else if (input == "2")
                {
                    int nextPrime = primeController.AddNextPrime(prime.primeList);
                    // If the data structure is empty, the program will enter the first prime (2) to the data structure.
                    if (nextPrime == 0)
                    {
                        view.PrintMenu();
                        prime.primeList.Add(2);
                        Console.WriteLine($"Added {nextPrime} to the data structure.");
                    }
                    else
                    {
                        view.PrintMenu();
                        prime.primeList.Add(nextPrime);
                        Console.WriteLine($"Added {nextPrime} to the data structure.");
                    }
                    Console.ReadLine();
                }

                // This option displays the data structure.
                else if (input == "3")
                {
                    if (prime.primeList.Count == 0)
                    {
                        view.PrintMenu();
                        Console.WriteLine("You need to add some prime numbers first!");
                    }

                    else
                    {
                        int lineBreak = 0;

                        Console.Clear();
                        foreach (var number in prime.primeList)
                        {
                            Console.Write($"|{number}| ");
                            lineBreak += 10;

                            if (lineBreak >= 40)
                            {
                                Console.WriteLine();
                                lineBreak = 0;
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }
        }

        // This method prints out the menu in the console.
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(
$@"__________________________________________________
|                                                |
|        ___   ___   _   _      ____  __         |
|       | |_) | |_) | | | |\/| | |_  ( (`        |
|       |_|   |_| \ |_| |_|  | |_|__ _)_)        |
|                                                |
|________________________________________________|
|                                                |
|                                                |
|       (1) Submit a prime number                |
|                                                |
|                                                |
|       (2) Add the following prime number       |
|           to the data structure                |
|                                                |
|       (3) Display all prime numbers            |
|                                                |
|                                                |
|                                                |
|                                                |
|                                                |
|                                                |
|________________________________________________|");
        }
    }
}