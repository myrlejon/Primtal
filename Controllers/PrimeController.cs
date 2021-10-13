using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primtal.Controllers
{
    // This class provides methods that are useful for deciding if the user input is a prime or not.
    public class PrimeController
    {
        // This method checks for prime numbers.
        public bool AddPrime(int prime)
        {
            bool isPrime = true;
            int[] array = new int[prime];

            for (int i = 0; i < prime; i++)
            {
                array[i] = i;
            }

            for (int i = 2; i < array.Length; i++)
            {
                if (prime % i == 0)
                {
                    isPrime = false;
                }
            }

            if (prime == 1 || prime == 0)
            {
                isPrime = false;
            }

            return isPrime;
        }

        // This method checks if the user input is valid.
        public int AcceptableInput()
        {
            var view = new View();
            int input;
            int number = 0;
            bool loop = true;
            
            while (loop)
            {
                view.PrintMenu();
                Console.Write("Enter a prime number:   ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    view.PrintMenu();
                    Console.WriteLine("Please enter a valid input.");
                    Console.ReadLine();
                }
                else if (input < 0)
                {
                    view.PrintMenu();
                    Console.WriteLine("Negative numbers can't be primes.");
                    Console.ReadLine();
                }
                else
                {
                    number = input;
                    loop = false;
                }
            }
            return number;
        }

        // This method adds the following prime number in the data structure.
        public int AddNextPrime(List<int> primeList)
        {
            int prime = 0;

            if (primeList.Count > 0)
            {
                prime = primeList.Max();
                bool searchPrime = true;
                
                while (searchPrime)
                {
                    prime++;
                    if (AddPrime(prime))
                    {
                        break;
                    }
                }
            }
            return prime;
        }

    }
}
