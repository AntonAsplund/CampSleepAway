using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund
{
    public static class UserInputs
    {
        /// <summary>
        /// Gets the users input for main menu choice
        /// </summary>
        /// <returns></returns>
        public static int GetUserInputMainMenu()
        {
            int userMainMenuChoice = 0;
            bool correctUserInput = false;

            while (correctUserInput == false)
            {
                correctUserInput = int.TryParse(Console.ReadLine(), out userMainMenuChoice);
                if (correctUserInput == false)
                {
                    Console.Write("Please enter a correct number without letters: ");
                }
                if (userMainMenuChoice == 99)
                { 
                    //User have choosen to acess admin menu
                }
                else if (userMainMenuChoice < 1 || userMainMenuChoice > 12)
                {
                    Console.WriteLine("Please enter a number between 1 and 13");
                    correctUserInput = false;
                }
            }

            return userMainMenuChoice;
        }
        /// <summary>
        /// Retrieves the validation of the users entered password
        /// </summary>
        /// <returns></returns>
        public static bool GetCorrectPassword()
        {
            int enteredPassword = 0;

            bool sucessfullPasswordInput = int.TryParse(Console.ReadLine(), out enteredPassword);
            if (enteredPassword == 1234)
            {
                Console.WriteLine("You have entered the correct password");
            }
            else
            {
                Console.WriteLine("You have entered an incorrect password");
                sucessfullPasswordInput = false;
            }

            return sucessfullPasswordInput;
        }

        public static int GetOneToTwo()
        {
            bool correctUserInput = false;
            int userInput = 0;

            Console.WriteLine("\nPlease enter a number between one and two: ");


            while (correctUserInput == false)
            {
                correctUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (correctUserInput == false)
                {
                    Console.Write("Please enter a correct number: ");
                }
                if (userInput < 1 || userInput > 2)
                {
                    Console.WriteLine("Please enter a number between 1 and 2");
                    correctUserInput = false;
                }
            }

            Console.Clear();

            return userInput;
        }

        public static int GetOneToFive()
        {
            bool correctUserInput = false;
            int userInput = 0;

            Console.WriteLine("\nPlease enter a number between one and five: ");


            while (correctUserInput == false)
            {
                correctUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (correctUserInput == false)
                {
                    Console.Write("Please enter a correct number: ");
                }
                if (userInput < 1 || userInput > 5)
                {
                    Console.WriteLine("Please enter a number between 1 and 5");
                    correctUserInput = false;
                }
            }

            Console.Clear();

            return userInput;
        }

        public static string GetNotNullStringInput()
        {
            bool sucessfullInput = false;
            string input = "";

            while (sucessfullInput == false)
            {
                input = Console.ReadLine();
                if (input.Length < 1)
                {
                    sucessfullInput = false;
                }
                else
                {
                    sucessfullInput = true;
                }
            }

            return input;
        }

        public static int GetSSN()
        {
            bool sucessfullInput = false;
            int socialSecurityNumber = 0;

            while (sucessfullInput == false)
            {
                sucessfullInput = int.TryParse(Console.ReadLine(), out socialSecurityNumber);
                if (sucessfullInput == false || socialSecurityNumber.ToString().Length != 9)
                {
                    Console.WriteLine("Please enter a correct 9 digit number");
                    Console.Write("Try again:  ");
                    sucessfullInput = false;
                }
            }

            return socialSecurityNumber;
        
        }

        public static int GetPhoneNumber()
        {
            bool sucessfullInput = false;
            int phoneNumber = 0;

            while (sucessfullInput == false)
            {
                sucessfullInput = int.TryParse(Console.ReadLine(), out phoneNumber);
                if (sucessfullInput == false )
                {
                    Console.WriteLine("Please enter a correct number");
                    Console.Write("Try again:  ");
                    sucessfullInput = false;
                }
            }

            return phoneNumber;
        }

        public static Camper GetACamperToAdd()
        {
            Console.WriteLine("Firstname: ");

            string firstName = GetNotNullStringInput();

            Console.WriteLine("Lastname: ");

            string lastName = GetNotNullStringInput();

            Console.WriteLine("Social security number: ");

            int socialSecurityNumber = GetSSN();

            return new Camper() { FirstName = firstName, LastName = lastName, SocialSecurityNumber = socialSecurityNumber };
        }

        internal static NextOfKin GetANextOfKinToAdd(int camperID)
        {
            Console.WriteLine("Firstname: ");

            string firstName = GetNotNullStringInput();

            Console.WriteLine("Lastname: ");

            string lastName = GetNotNullStringInput();

            Console.WriteLine("Social security number: ");

            int socialSecurityNumber = GetSSN();

            Console.WriteLine("Phone number: ");

            int phoneNumber = GetPhoneNumber();

            return new NextOfKin() { FirstName = firstName, LastName = lastName, SocialSecurtyNumber = socialSecurityNumber, PhoneNumber = phoneNumber, CamperID = camperID };
        }

        public static Counselor GetACounselorToAdd()
        {
            Console.WriteLine("Firstname: ");

            string firstName = GetNotNullStringInput();

            Console.WriteLine("Lastname: ");

            string lastName = GetNotNullStringInput();

            Console.WriteLine("Social security number: ");

            int socialSecurityNumber = GetSSN();

            Console.WriteLine("Phone number: ");

            int phoneNumber = GetPhoneNumber();

            return new Counselor() { FirstName = firstName, LastNAme = lastName, PhoneNumber = phoneNumber, SocialSecurityNumber = socialSecurityNumber };

        }

        internal static int GetATrueIntNumber()
        {
            bool sucessfullInput = false;
            int trueIntNumber = 0;

            while (sucessfullInput == false)
            {
                sucessfullInput = int.TryParse(Console.ReadLine(), out trueIntNumber);
                if (sucessfullInput == false)
                {
                    Console.WriteLine("Please enter a true reasonable number");
                    Console.Write("Try again:  ");
                    sucessfullInput = false;
                }
            }

            return trueIntNumber;
        }

        internal static int GetOneToSix()
        {
            bool correctUserInput = false;
            int userInput = 0;

            Console.WriteLine("\nPlease enter a number between one and six: ");


            while (correctUserInput == false)
            {
                correctUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (correctUserInput == false)
                {
                    Console.Write("Please enter a correct number: ");
                }
                if (userInput < 1 || userInput > 6)
                {
                    Console.WriteLine("Please enter a number between 1 and 6");
                    correctUserInput = false;
                }
            }

            Console.Clear();

            return userInput;
        }

        internal static int GetOneToThree()
        {
            bool correctUserInput = false;
            int userInput = 0;

            Console.WriteLine("\nPlease enter a number between one and three: ");


            while (correctUserInput == false)
            {
                correctUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (correctUserInput == false)
                {
                    Console.Write("Please enter a correct number: ");
                }
                if (userInput < 1 || userInput > 3)
                {
                    Console.WriteLine("Please enter a number between 1 and 3");
                    correctUserInput = false;
                }
            }

            Console.Clear();

            return userInput;
        }
    }
}
