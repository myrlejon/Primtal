using System;

namespace Primtal
{
    public class View
    {
        public static void Menu()
        {
            string spacing = "                        ";
            var primeController = new Controllers.PrimeController();
            var view = new View();

            Console.SetWindowSize(50, 25);
            Console.Clear();

            bool menuLoop = true;
            while (menuLoop)
            {
                view.PrintMenu();
                Console.Write(spacing);
                string input = Console.ReadLine();

                //TODO: Lägg till en try catch som kollar om det är 0, negativt eller en sträng
                if (input == "1")
                {
                    int primeInt = primeController.AcceptableInput();

                    if (primeController.AddPrime(primeInt))
                    {
                        view.PrintMenu();
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

                else if (input == "2")
                {
                }
                else if (input == "3")
                {
                }
            }
        }

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