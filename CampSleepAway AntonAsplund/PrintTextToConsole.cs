using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepAway_AntonAsplund.Database;

namespace CampSleepAway_AntonAsplund
{
    public static class PrintTextToConsole
    {
        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PresentAsciiArtMainMenu()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"_________");
            Console.WriteLine(@"\_   ___ \_____    _____ ______                                   ");
            Console.WriteLine(@"/    \  \/\__  \  /     \\____ \                                  ");
            Console.WriteLine(@"\     \____/ __ \|  Y Y  \  |_> >                                 ");
            Console.WriteLine(@" \______  (____  /__|_|  /   __/");
            Console.WriteLine(@"        \/     \/      \/|__|");
            Console.WriteLine(@"  _________.__                       ________");
            Console.WriteLine(@" /   _____/|  |   ____   ____ ______ \_____  \___  __ ___________");
            Console.WriteLine(@" \_____  \ |  | _/ __ \_/ __ \\____ \ /   |   \  \/ // __ \_  __ \");
            Console.WriteLine(@" /        \|  |_\  ___/\  ___/|  |_> >    |    \   /\  ___/|  | \/");
            Console.WriteLine(@"/_______  /|____/\___  >\___  >   __/\_______  /\_/  \___  >__|");
            Console.WriteLine(@"        \/           \/     \/|__|           \/          \/       ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void GetMainMenu()
        {
            PresentAsciiArtMainMenu();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("1.   Add new Camper");
            Console.WriteLine("2.   Add new Next-of-kin");
            Console.WriteLine("3.   Update camper");
            Console.WriteLine("4.   Update Next-of-kin");
            Console.WriteLine("5.   Next-of-kin Checkin/Checkout");
            Console.WriteLine("6.   Print all current campers");
            Console.WriteLine("7.   Print all counselors");
            Console.WriteLine("8.   Print specific camper and Next-of-kin");
            Console.WriteLine("9.   Print from archive");
            Console.WriteLine("10.  Add new counselor");
            Console.WriteLine("11.  Update counselor");
            Console.WriteLine("12.  Exit the progam");

        }

        public static void ExitFromMainMenu()
        {
            Console.WriteLine("Thank you for using Camp SleepOver EntityFrameWork CodeFirst Edition.");
            Console.WriteLine("Press any key shut down the program...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AdminMenu()
        {
            Console.WriteLine("You have choosen admin menu.");
            Console.Write("Enter password:  ");
        }

        public static void AddCamperMenu()
        {
            Console.WriteLine("Do you want to assign the camper to a cabin?");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        internal static void AddNewNextOfKinMenu()
        {
            Console.WriteLine("What is the campers social security number?");
            Console.Write("Enter 9 digit number: ");
        }

        internal static void UpdateCamperMenu()
        {
            Console.WriteLine("Enter the campers social security number");
        }

        internal static void UpdateCamperWhichAttribute()
        {
            Console.WriteLine("Which attribute do you want to update?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Social security number");
            Console.WriteLine("4. Cabin number");
            Console.WriteLine("5. Check out camper");
            Console.WriteLine("6. No attribute");
        }

        internal static void NextOfKinMenuSSN()
        {
            Console.WriteLine("Enter the next of kins social security number");
        }

        internal static void NextOfKinMenuAttribute()
        {
            Console.WriteLine("Which attribute do you want to update?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Phone number");
            Console.WriteLine("4. Social security number");
            Console.WriteLine("5. Remove next of kin");
            Console.WriteLine("6. No attribute");
        }

        internal static void NextOfKinCheckInOrOutChoice()
        {
            Console.WriteLine("Do you want to check in the next of kin?");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        internal static void AddNewCounselorMenu()
        {
            Console.WriteLine("Do you want to assign the counselor to a cabin?");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        internal static void PrintAllCampers(List<Camper> allCampers, List<Cabin> allCabins)
        {
            allCampers.OrderBy(C => C.CabinID);

            foreach (var camper in allCampers)
            {
                Console.WriteLine("--------------");
                Console.WriteLine($"{camper.FirstName}");
                Console.WriteLine($"{camper.LastName}");
                if (camper.CabinID == null)
                {
                    Console.WriteLine("Cabin number: No cabin has been assinged");
                }
                else
                {
                    Console.WriteLine($"Cabin number: {allCabins.Where(C => C.CabinID == camper.CabinID).FirstOrDefault().CabinNumber}");
                }

            }
        }

        internal static void PrintAllCounselors()
        {

            using (var db = new CampSleepAwayContext())
            {

                try
                {
                    var allCounselorsQuery = db.Counselors.ToList();


                    foreach (var counselor in allCounselorsQuery)
                    {
                        Console.WriteLine("-----------");
                        Console.WriteLine($"{counselor.FirstName}");
                        Console.WriteLine($"{counselor.LastNAme}");
                        try
                        {
                            Console.WriteLine($"Cabin number: {counselor.Cabin.CabinNumber}");
                        }
                        catch 
                        {
                            Console.WriteLine("Cabin number: (No cabin assigned)");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                }
                

                
            }

            
        }

        internal static void CounselorMenuSSN()
        {
            Console.WriteLine("Enter the counselors social security number");
        }

        internal static void CounselorMenuAttribute()
        {
            Console.WriteLine("Which attribute do you want to update?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Phone number");
            Console.WriteLine("4. Social security number");
            Console.WriteLine("5. Assign/Remove to/from cabin ");
            Console.WriteLine("6. No attribute");
        }

        internal static void UpdateCounselorCabinMenu()
        {
            Console.WriteLine("Do you want to assign to a new cabin or remove from existing?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Assign to new cabin");
            Console.WriteLine("2. Remove from existing");
        }

        internal static void AssignCounselorToCabin()
        {
            Console.WriteLine("To which cabin number do you want to assign the counselor?");
            Console.Write("Enter cabin number: ");
        }

        internal static void PrintSpecificMenu()
        {
            Console.WriteLine("About whom do you want to retrieve info?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Camper");
            Console.WriteLine("2. Next of kin");
            Console.WriteLine("3. Counselor");
        }

        internal static void PrintSpecificSSN()
        {
            Console.Write("Enter social security number of the person: ");
        }

        internal static void PrintSpecificCamper(Camper camper, List<NextOfKin> nextOfKins)
        {
            string noCabin = "No assigned cabin";

            Console.WriteLine("***CAMPER***");
            Console.WriteLine($"Firstname: {camper.FirstName}");
            Console.WriteLine($"Lastname: {camper.LastName}");
            Console.WriteLine($"SSN: {camper.SocialSecurityNumber}");
            Console.WriteLine($"Cabin number: {(camper.CabinID != null ? camper.Cabin.CabinNumber.ToString() : noCabin)}");

            if (nextOfKins.Count < 1)
            {
                Console.WriteLine($"***Next of kin***");
                Console.WriteLine("No next of kin exists in database");
            }
            else 
            {
                foreach (var nextOfKin in nextOfKins)
                {
                    PrintSpecificNextOfKin(nextOfKin);
                }
            }
        }

        internal static void PrintSpecificNextOfKin(NextOfKin nextOfKin)
        {
            Console.WriteLine($"***Next of kin***");
            Console.WriteLine($"Firstname: {nextOfKin.FirstName}");
            Console.WriteLine($"Lastname: {nextOfKin.LastName}");
            Console.WriteLine($"Phone number: {nextOfKin.PhoneNumber}");
            Console.WriteLine($"SSN: {nextOfKin.SocialSecurtyNumber}");
            using (var db = new CampSleepAwayContext())
            {
                try
                {
                    var nextOfKinPresent = db.NextOfKinCheckInCheckOuts.Where(Nx => Nx.NextOfKinID == nextOfKin.NextOfKinID).FirstOrDefault<NextOfKinCheckInCheckOut>();
                    
                    if (nextOfKinPresent != null)
                    {
                        Console.WriteLine($"Is present in camp: {(nextOfKinPresent.IsPresent ? "Yes" : "No")}");
                    }
                    else
                    {
                        Console.WriteLine("Is present in camp: The person has never checked in on Camp SleepOver");
                    }
                }
                catch
                {
                    Console.WriteLine("Is present in camp: The person has never checked in on Camp SleepOver");
                }
            }
        }

        internal static void PrintSpecificCounselor(Counselor counselor)
        {
            Console.WriteLine($"***Counselor***");
            Console.WriteLine($"Firstname: {counselor.FirstName}");
            Console.WriteLine($"Lastname: {counselor.LastNAme}");
            Console.WriteLine($"Phone number: {counselor.PhoneNumber}");
            Console.WriteLine($"SSN: {counselor.SocialSecurityNumber}");
            if (counselor.Cabin != null)
            {
                Console.WriteLine($"Cabin number: {counselor.Cabin.CabinNumber}");
            }
            else
            {
                Console.WriteLine("Cabin number: Counselor is assigned to no cabin");
            }
        }

        internal static void PrintHistoryMenu()
        {
            Console.WriteLine("Print history from?");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Camper");
            Console.WriteLine("2. Next of kin");
            Console.WriteLine("3. Counselor");
        }

        internal static void PrintListCamperHistory(List<CamperHistory> allCamperHistory, List<Cabin> allCabins)
        {
            int counterShowTen = 1;

            foreach (var camper in allCamperHistory)
            {
                Console.WriteLine("***CAMPER***");
                Console.WriteLine($"Firstname: {camper.FirstName}");
                Console.WriteLine($"Lastname: {camper.LastName}");
                Console.WriteLine($"SSN: {camper.SocialSecurityNumber}");

                if (camper.CabinID == null)
                {
                    Console.WriteLine($"Cabin number: No assigned cabin");
                }
                else 
                {
                    foreach (var cabin in allCabins)
                    {
                        if (camper.CabinID == cabin.CabinID)
                        {
                            Console.WriteLine($"Cabin number: {cabin.CabinNumber} ---> {cabin.CabinNickName}");
                        }
                    }
                }
                Console.WriteLine($"Camper ID: {camper.CamperID} \n");

                Console.WriteLine($" {(camper.IsActive ? "Camper added/updated" : "Camper checked out:")}");
                Console.WriteLine($" {camper.TimeStamp}\n");

                if (counterShowTen % 10 == 0)
                {
                    Console.WriteLine("Press any key to continue to show next 10 campers");
                    Console.ReadKey();
                }
                counterShowTen++;
            }
        }

        internal static void PrintRemoveCamperMenu(Camper camperToUpdate)
        {
            Console.WriteLine($"Do you really want to check out {camperToUpdate.FirstName} {camperToUpdate.LastName} from Camp SleepOver?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        internal static void PrintListNextOfKinHistory(List<NextOfKinHistory> allNextOfKinHistory)
        {
            foreach (var nextOfKin in allNextOfKinHistory)
            {
                Console.WriteLine("***Next of kin***");
                Console.WriteLine($"Firstname: {nextOfKin.FirstName}");
                Console.WriteLine($"Lastname: {nextOfKin.LastName}");
                Console.WriteLine($"Phone number: {nextOfKin.PhoneNumber}");
                Console.WriteLine($"SSN: {nextOfKin.SocialSecurityNumber}");
                Console.WriteLine($"Campers ID: {nextOfKin.CamperID}");
                Console.WriteLine($"Next of kin ID: {nextOfKin.NextOfKinID}\n");

                Console.WriteLine($" {(nextOfKin.IsActive ? "Next of kin added: " : "Next of kin removed: ")} ");
                Console.WriteLine($" {nextOfKin.TimeStamp}\n");

            }
        }

        internal static void PrintListCounselorHistory(List<CounselorHistory> allCounselorHistory, List<Cabin> allCabins)
        {
            foreach (var Counselor in allCounselorHistory)
            {
                Console.WriteLine("***Counselor***");
                Console.WriteLine($"Firstname: {Counselor.FirstName}");
                Console.WriteLine($"Lastname: {Counselor.LastName}");
                Console.WriteLine($"Phone number: {Counselor.PhoneNumber}");
                Console.WriteLine($"SSN: {Counselor.SocialSecurityNumber}");
                Console.WriteLine($"Next of kin ID: {Counselor.CounselorID}\n");

                if (Counselor.CabinID == null)
                {
                    Console.WriteLine($"Cabin number: No assigned cabin");
                }
                else
                {
                    foreach (var cabin in allCabins)
                    {
                        if (Counselor.CabinID == cabin.CabinID)
                        {
                            Console.WriteLine($"Cabin number: {cabin.CabinNumber} ---> {cabin.CabinNickName}");
                        }
                    }
                }

                Console.WriteLine($"\n Counselor added/ updated");
                Console.WriteLine($" {Counselor.TimeStamp}\n");

            }
        }

        internal static void PrintRemoveNextOfKinMenu(NextOfKin nextOfKinToUpdate)
        {
            Console.WriteLine($"Do you really want to remove next of kin {nextOfKinToUpdate.FirstName} {nextOfKinToUpdate.LastName} from Camp SleepOver?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        internal static void PrintRemoveCounselorMenu(Counselor counselorToUpdate)
        {
            Console.WriteLine($"Do you really want to remove next of kin {counselorToUpdate.FirstName} {counselorToUpdate.LastNAme} from Camp SleepOver?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }
    }
}
