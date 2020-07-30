using System;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Validate a pin:
            Console.WriteLine("Please specify a pin.");
            string userPin = Console.ReadLine();
            bool isValidPin = false;
            //int n; 
            bool isNumericPin = int.TryParse(userPin, out _);
            //Console.WriteLine($"isNumericPin bool value: {isNumericPin}");

            if (userPin.Length >= 4 && userPin.Length <= 8 && isNumericPin == true)
            {
                isValidPin = true;
                Console.WriteLine("Pin is valid!");
            }
            else
            {
                Console.WriteLine("Sorry, it's not a valid pin.");
            }
            Console.ReadKey();
        }
    }
}
