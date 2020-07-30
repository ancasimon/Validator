using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //PART 1: Validate a pin:
            Console.WriteLine("Please specify a pin.");
            string userPin = Console.ReadLine();
            //bool isValidPin = false;
            //int n; 
            bool isNumericPin = int.TryParse(userPin, out _);
            //Console.WriteLine($"isNumericPin bool value: {isNumericPin}");

            if (string.IsNullOrEmpty(userPin))
            {
                Console.WriteLine("You must enter a pin first!");
            } 
            else
            {
                if (userPin.Length >= 4 && userPin.Length <= 8 && isNumericPin == true)
                {
                    //isValidPin = true;
                    Console.WriteLine("Pin is valid!");
                }
                else
                {
                    Console.WriteLine("Sorry, it's not a valid pin.");
                }
            }
            



            //PART 2: Validate phone number:
            Console.WriteLine("Please enter a phone number.");
            string userPhoneNumber = Console.ReadLine();

            //The next step allows the valid phone number characters in (space, -, () ), but it replaces them with no space and declares a new variable to store the new string created as a result of the Replace method.
            string trimmedPhoneNumber = userPhoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            //Console.WriteLine(trimmedPhoneNumber);

            //Then we check that the trimmed string includes only numeric characters:
            bool isNumericOnly = Int64.TryParse(trimmedPhoneNumber, out long _);
            //Console.WriteLine($"numeric only? {isNumericOnly}");

            //Next we will count the number of numeric characters in the phone number:
            int digitCount = 0;
            foreach(char c in trimmedPhoneNumber)
            {
                if (Char.IsDigit(c))
                    digitCount++;
            }
            //Console.WriteLine("digit count: "+digitCount);

            //Last we make sure the first 3 characters are not 555:
            string userPhoneFirstThree;
            if (trimmedPhoneNumber.Length > 2)
            {
                userPhoneFirstThree = trimmedPhoneNumber.Substring(0, 3);
                //Console.WriteLine($"first 3 characters are: {userPhoneFirstThree}");
            } 
            else
            {
                userPhoneFirstThree = "";
            }

            if (string.IsNullOrEmpty(userPhoneNumber))
            {
                Console.WriteLine("You must enter a phone number!");
            }
            else
            {
                if (isNumericOnly == true && digitCount == 10 && userPhoneFirstThree != "555")
                {
                    Console.WriteLine("Valid phone number!");
                }
                else
                {
                    Console.WriteLine("Sorry, not a valid phone number! Try again!");
                }
            }




            //PART 3: Validate email address:
            Console.WriteLine("Please enter an email address.");
            string userEmail = Console.ReadLine();
            string userName;
            string domainName;
            string dotComString;
            int indexPositionOfAt = userEmail.IndexOf('@');
            if (indexPositionOfAt == -1)
            {
                Console.WriteLine("Please enter a VALID email address!!");
            }
            else //Feels I should have en else here because otherwise, I get an error if the domainName substring below has to start an a nonexistent number ....
            {
                userName = userEmail.Substring(0, indexPositionOfAt);
                domainName = userEmail.Substring(indexPositionOfAt+1); //Added plus 1 so that I don't include the @ in the domain name - and thus can make sure it doesn't include extra @!!!

                int indexPositionOfDot = domainName.IndexOf('.');

                if (indexPositionOfDot == -1)
                {
                    Console.WriteLine("Please enter a VALID email address!!");
                }
                else
                {
                    dotComString = domainName.Substring(indexPositionOfDot);

                    bool containsMoreThanOneAt = domainName.Contains("@");

                    //Console.WriteLine($"index of at: {indexPositionOfAt}");
                    //Console.WriteLine($"index of dot: {indexPositionOfDot}");
                    //Console.WriteLine($"more than one at: {containsMoreThanOneAt}");
                    //Console.WriteLine($"username: {userName}");
                    //Console.WriteLine($"domain: {domainName}");
                    //Console.WriteLine($"dotcom string: {dotComString}");

                    if (indexPositionOfAt != -1 &&
                            indexPositionOfDot != -1 &&
                            containsMoreThanOneAt == false &&
                            userName.Length > 0 &&
                            domainName.Length > 0 &&
                            dotComString.Length > 0)
                        {
                            Console.WriteLine("You got it! Valid!!!");
                        }
                        else
                        {
                            Console.WriteLine("Sorry - invalid email address. Please try again!");
                        }

                }

            }


            //PART 4 - SpongeBob SquarePants???



            //PART 5 - Power Ranger name validation:
            Console.WriteLine("Who's your favorite Power Ranger?");
            string userPowerRanger = Console.ReadLine();

            //list of names here:
            var powerRangerNames = new List<string>() { "Jason Lee Scott", "Rocky DeSantos", "Zack Taylor", "Adam Park", "Billy Cranston", "Trini Kwan", "Aisha Campbell", "Kimberly Ann Hart", "Katherine Hillard", "Tommy Oliver"};

            //bool check:
            bool isValidPowerRanger = false;

            //loop to compare each string to the user's input:
            foreach (string name in powerRangerNames)
            {
                if (userPowerRanger.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    isValidPowerRanger = true;
                }
            }

            if (isValidPowerRanger == true)
            {
                Console.WriteLine("Good one!");
            }
            else
            {
                Console.WriteLine("Did you spell it correctly? Try again!");
            }


            //PART 6 - Palindrome validation:
            Console.WriteLine("What's your favorite palindrome?? You know - a word, phrase, or sequence that reads the same backward as forward - for ex: madam, nurses run, racecar, - A man, a plan, a canal, Panama! ");
            string userString, reversedUserString;
            userString = Console.ReadLine();
            char[] charArrayFromUserString = userString.ToCharArray();
            Array.Reverse(charArrayFromUserString);
            reversedUserString = new string(charArrayFromUserString);
            bool isPalindrome = userString.Equals(reversedUserString, StringComparison.OrdinalIgnoreCase);
            if (userString.Length > 0 && isPalindrome == true)
            {
                Console.WriteLine("Yes! " + userString + " is a palindrome!!");
            } else
            {
                Console.WriteLine("Bummer: " + userString + " is not a palindrome ...");
            }



            Console.ReadKey();

        }
    }
}
