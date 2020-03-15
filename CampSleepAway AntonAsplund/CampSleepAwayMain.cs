using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepAway_AntonAsplund.Database;

namespace CampSleepAway_AntonAsplund
{
    class CampSleepAwayMain
    {
        public CampSleepAwayMain(int numberOfCabins, int sizeOfCabin)
        {
            using (var db = new CampSleepAwayContext())
            {
                //Generates given number of cabins the first time the progam is initialized
                if (db.Cabins.FirstOrDefault() == null)
                {
                    for (int i = 0; i < numberOfCabins; i++)
                    {
                        db.Cabins.Add(new Cabin() { FreeCamperBunks = sizeOfCabin, TotalCamperBunks = sizeOfCabin, CabinNumber = i + 1, CabinNickName = (i + 10).ToString() });
                        db.SaveChanges();
                    }
                }
            }

        }

        public void RunMain()
        {

            bool stayInMainMenu = true;


            while (stayInMainMenu)
            {
                PrintTextToConsole.GetMainMenu();
                int mainMenuChoice = UserInputs.GetUserInputMainMenu();
                Console.Clear();

                switch (mainMenuChoice)
                {
                    case 1: //Add new camper DONE
                        {
                            PrintTextToConsole.AddCamperMenu();
                            int addCamperMenuChoice = UserInputs.GetOneToTwo();

                            switch (addCamperMenuChoice)
                            {
                                case 1: //Assign to a cabin
                                    {
                                        var camper = UserInputs.GetACamperToAdd();

                                        using (var db = new CampSleepAwayContext())
                                        {
                                            var cabin = db.Cabins.Where(C => C.FreeCamperBunks > 0).FirstOrDefault<Cabin>();

                                            cabin.FreeCamperBunks += (-1);

                                            camper.Cabin = cabin;

                                            db.Campers.Add(camper);
                                            try
                                            {
                                                db.SaveChanges();

                                                var camperHistory = HelpMethods.GetACamperHistory(camper, true);
                                                db.CamperHistories.Add(camperHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }

                                            Console.WriteLine($"The camper has been assinged to cabin number {cabin.CabinNumber}");
                                        }            
                                        break;
                                    }
                                case 2: //No cabin assigned
                                    {
                                        var camper = UserInputs.GetACamperToAdd();

                                        using (var db = new CampSleepAwayContext())
                                        {

                                            db.Campers.Add(camper);

                                            try
                                            {
                                                db.SaveChanges();

                                                var camperHistory = HelpMethods.GetACamperHistory(camper, true);
                                                db.CamperHistories.Add(camperHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                        }

                                        break;
                                    }
                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 2: //Add new nextofkin DONE
                        {
                            PrintTextToConsole.AddNewNextOfKinMenu();
                            int camperSSN = UserInputs.GetSSN();

                            using (var db = new CampSleepAwayContext())
                            {
                                var camper = new Camper();

                                try
                                {
                                    camper = db.Campers.Where(C => C.SocialSecurityNumber == camperSSN).FirstOrDefault<Camper>();
                                }
                                catch
                                {
                                    Console.WriteLine("No camper with that name could be found");
                                    PrintTextToConsole.ReturnToMainMenu();
                                    break;
                                }

                                var nextOfKin = UserInputs.GetANextOfKinToAdd(camper.CamperId);

                                db.NextOfKins.Add(nextOfKin);

                                try
                                {
                                    db.SaveChanges();

                                    var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKin, true);
                                    db.NextOfKinHistories.Add(nextOfKinHistory);
                                    db.SaveChanges();
                                }
                                catch
                                {
                                    Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                }
                                

                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 3: //Update camper DONE
                        {
                            PrintTextToConsole.UpdateCamperMenu();
                            int camperSSN = UserInputs.GetSSN();
                            Camper camperToUpdate = new Camper();

                            using (var db = new CampSleepAwayContext())
                            {

                                try
                                {
                                    camperToUpdate = db.Campers.Where(C => C.SocialSecurityNumber == camperSSN).FirstOrDefault<Camper>();
                                }
                                catch
                                {
                                    Console.WriteLine("The camper in question could not be found.");
                                    PrintTextToConsole.ReturnToMainMenu();
                                    break;
                                }

                                PrintTextToConsole.UpdateCamperWhichAttribute();
                                int userUpdateCamperChoice = UserInputs.GetOneToSix();

                                switch (userUpdateCamperChoice)
                                {
                                    case 1:
                                        {
                                            camperToUpdate.FirstName = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var camperHistory = HelpMethods.GetACamperHistory(camperToUpdate, true);
                                                db.CamperHistories.Add(camperHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            camperToUpdate.LastName = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var camperHistory = HelpMethods.GetACamperHistory(camperToUpdate, true);
                                                db.CamperHistories.Add(camperHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            camperToUpdate.SocialSecurityNumber = UserInputs.GetSSN();
                                            try
                                            {
                                                db.SaveChanges();

                                                var camperHistory = HelpMethods.GetACamperHistory(camperToUpdate, true);
                                                db.CamperHistories.Add(camperHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("To which cabin do you want to move the camper?");
                                            try
                                            {
                                                var newCabin = db.Cabins.Where(C => C.CabinNumber == UserInputs.GetATrueIntNumber()).FirstOrDefault<Cabin>();

                                                if (newCabin.FreeCamperBunks > 0)
                                                {

                                                    var oldCabin = camperToUpdate.Cabin;

                                                    camperToUpdate.Cabin = newCabin;
                                                    

                                                    
                                                    try
                                                    {
                                                        db.SaveChanges();
                                                        newCabin.FreeCamperBunks += (-1);
                                                        oldCabin.FreeCamperBunks += 1;
                                                        var camperHistory = HelpMethods.GetACamperHistory(camperToUpdate, true);
                                                        db.CamperHistories.Add(camperHistory);
                                                        db.SaveChanges();
                                                    }
                                                    catch 
                                                    {
                                                        Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                                    }
                                                    

                                                }
                                                else
                                                {
                                                    Console.WriteLine("No free camper bunks in provided cabin");
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No cabin by that number could be found");
                                            }
                                            
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            PrintTextToConsole.PrintRemoveCamperMenu(camperToUpdate);

                                            int userRemoveCamperMenuChoice = UserInputs.GetOneToTwo();

                                            switch (userRemoveCamperMenuChoice)
                                            {
                                                case 1:
                                                    {
                                                        var camperHistory = HelpMethods.GetACamperHistory(camperToUpdate, false);

                                                        camperToUpdate.Cabin.FreeCamperBunks += 1;

                                                        db.Campers.Remove(camperToUpdate);
                                                        try
                                                        {
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when removing camper. Please contact support if the problem persists.");
                                                        }

                                                        db.CamperHistories.Add(camperHistory);

                                                        try
                                                        {
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when adding to camper history. Please contact support if the problem persists.");
                                                        }
                                                        
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        break;
                                                    }
                                            }


                                            break;
                                        }
                                    case 6:
                                        {
                                            break;
                                        }
                                }
                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 4: //Update nextofkin DONE
                        {
                            PrintTextToConsole.NextOfKinMenuSSN();
                            int nextOfKinSSN = UserInputs.GetSSN();
                            var nextOfKinToUpdate = new NextOfKin();

                            using (var db = new CampSleepAwayContext())
                            {

                                try
                                {
                                    nextOfKinToUpdate = db.NextOfKins.Where(C => C.SocialSecurtyNumber == nextOfKinSSN).FirstOrDefault<NextOfKin>();
                                }
                                catch
                                {
                                    Console.WriteLine("The next of kin in question could not be found.");
                                    PrintTextToConsole.ReturnToMainMenu();
                                    break;
                                }

                                PrintTextToConsole.NextOfKinMenuAttribute();
                                int userUpdateNextOfKinChoice = UserInputs.GetOneToSix();

                                switch (userUpdateNextOfKinChoice)
                                {
                                    case 1:
                                        {
                                            nextOfKinToUpdate.FirstName = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKinToUpdate, true);
                                                db.NextOfKinHistories.Add(nextOfKinHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            nextOfKinToUpdate.LastName = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKinToUpdate, true);
                                                db.NextOfKinHistories.Add(nextOfKinHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            nextOfKinToUpdate.PhoneNumber = UserInputs.GetPhoneNumber();
                                            try
                                            {
                                                db.SaveChanges();

                                                var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKinToUpdate, true);
                                                db.NextOfKinHistories.Add(nextOfKinHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            nextOfKinToUpdate.SocialSecurtyNumber = UserInputs.GetSSN();
                                            try
                                            {
                                                db.SaveChanges();

                                                var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKinToUpdate, true);
                                                db.NextOfKinHistories.Add(nextOfKinHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            PrintTextToConsole.PrintRemoveNextOfKinMenu(nextOfKinToUpdate);

                                            int userRemoveNextOfKinMenuChoice = UserInputs.GetOneToTwo();

                                            switch (userRemoveNextOfKinMenuChoice)
                                            {
                                                case 1:
                                                    {
                                                        var nextOfKinHistory = HelpMethods.GetANextOfKinHistory(nextOfKinToUpdate, false);

                                                        db.NextOfKins.Remove(nextOfKinToUpdate);
                                                        try
                                                        {
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when removing next of kin. Please contact support if the problem persists.");
                                                        }

                                                        db.NextOfKinHistories.Add(nextOfKinHistory);

                                                        try
                                                        {
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when adding next of kin to history. Please contact support if the problem persists.");
                                                        }

                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            break;
                                        }
                                }

                            }


                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 5: //Nextofkin checkin/checkout DONE
                        {
                            PrintTextToConsole.NextOfKinMenuSSN();
                            int nextOfKinSSN = UserInputs.GetSSN();
                            var nextOfKin = new NextOfKin();

                            using (var db = new CampSleepAwayContext())
                            {

                                try
                                {
                                    nextOfKin = db.NextOfKins.Where(C => C.SocialSecurtyNumber == nextOfKinSSN).FirstOrDefault<NextOfKin>();
                                }
                                catch
                                {
                                    Console.WriteLine("The next of kin in question could not be found.");
                                    PrintTextToConsole.ReturnToMainMenu();
                                    break;
                                }

                                PrintTextToConsole.NextOfKinCheckInOrOutChoice();
                                int nextOfKinCheckInOrOurMenuChoice = UserInputs.GetOneToTwo();

                                switch (nextOfKinCheckInOrOurMenuChoice)
                                {
                                    case 1:
                                        {
                                            var nextOfKinCheckInCheckOut = HelpMethods.GetANextOFKinCheckInCheckOut(nextOfKin, true);

                                            try
                                            {
                                                db.NextOfKinCheckInCheckOuts.Add(nextOfKinCheckInCheckOut);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }

                                            break;
                                        }
                                    case 2:
                                        {
                                            var nextOfKinCheckInCheckOut = HelpMethods.GetANextOFKinCheckInCheckOut(nextOfKin, false);

                                            try
                                            {
                                                db.NextOfKinCheckInCheckOuts.Add(nextOfKinCheckInCheckOut);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }

                                            break;
                                        }
                                }
                            }
                                PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 6: //Print all  current campers DONE
                        {
                            var allCampers = new List<Camper>();
                            var allCabins = new List<Cabin>();

                            using (var db = new CampSleepAwayContext())
                            {
                                allCampers = db.Campers.ToList();
                                allCabins = db.Cabins.ToList();
                            }

                            PrintTextToConsole.PrintAllCampers(allCampers, allCabins);

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 7: //Print all current counselors DONE
                        {
                            PrintTextToConsole.PrintAllCounselors();

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 8: //Print specific camper, nextofkin or counselor DONE
                        {
                            PrintTextToConsole.PrintSpecificMenu();
                            int userInputPrintHistoryMenuChoice = UserInputs.GetOneToThree();
                            Console.Clear();

                            PrintTextToConsole.PrintSpecificSSN();
                            int specificEntitySSN = UserInputs.GetSSN();

                            switch (userInputPrintHistoryMenuChoice)
                            {
                                case 1:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            try
                                            {
                                                var camper = db.Campers.Where(C => C.SocialSecurityNumber == specificEntitySSN).FirstOrDefault<Camper>();
                                                var nextOfKin = db.NextOfKins.Where(Nx => Nx.CamperID == camper.CamperId).ToList();
                                                PrintTextToConsole.PrintSpecificCamper(camper, nextOfKin);
                                            }
                                            catch 
                                            {
                                                Console.WriteLine("No camper by that social security number has been found");
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            try
                                            {
                                                var nextOfKin = db.NextOfKins.Where(C => C.SocialSecurtyNumber == specificEntitySSN).FirstOrDefault<NextOfKin>();
                                                PrintTextToConsole.PrintSpecificNextOfKin(nextOfKin);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No camper by that social security number has been found");
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            try
                                            {
                                                var counselor = db.Counselors.Where(C => C.SocialSecurityNumber == specificEntitySSN).FirstOrDefault<Counselor>();
                                                PrintTextToConsole.PrintSpecificCounselor(counselor);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No camper by that social security number has been found");
                                            }
                                        }
                                        break;
                                    }
                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 9: //Print entire history tables for camper, nextofkin or counselor DONE
                        {
                            PrintTextToConsole.PrintHistoryMenu();
                            int userInputPrintHistoryMenuChoice = UserInputs.GetOneToThree();

                            switch (userInputPrintHistoryMenuChoice)
                            {
                                case 1:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            var allCamperHistory = db.CamperHistories.ToList();
                                            var allCabins = db.Cabins.ToList();
                                            PrintTextToConsole.PrintListCamperHistory(allCamperHistory, allCabins);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            var allNextOfKinHistory = db.NextOfKinHistories.ToList();
                                            PrintTextToConsole.PrintListNextOfKinHistory(allNextOfKinHistory);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        using (var db = new CampSleepAwayContext())
                                        {
                                            var allCounselorHistory = db.CounselorHistories.ToList();
                                            var allCabins = db.Cabins.ToList();
                                            PrintTextToConsole.PrintListCounselorHistory(allCounselorHistory, allCabins);
                                        }
                                        break;
                                    }
                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 10: //Add new counselor DONE
                        {
                            PrintTextToConsole.AddNewCounselorMenu();
                            int addNewCounselorMenuChoice = UserInputs.GetOneToTwo();

                            switch (addNewCounselorMenuChoice)
                            {
                                case 1:
                                    {
                                        var counselor = UserInputs.GetACounselorToAdd();
                                        int cabinIDToAddCounselorTo = 0;
                                        int cabinNumberToAddCounselorTo = 0;

                                        using (var db = new CampSleepAwayContext())
                                        {
                                            try
                                            {
                                                var cabin = db.Cabins.Where(C => !db.CabinsCounselors.Select(CC => CC.CabinID).Contains(C.CabinID)).ToList();

                                                cabinIDToAddCounselorTo = cabin[0].CabinID;
                                                cabinNumberToAddCounselorTo = cabin[0].CabinNumber;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No free space in any cabins for new counselors. Try creating new counselors without assigning a cabin.");
                                                break;
                                            }

                                            db.CabinsCounselors.Add(new CabinsCounselor() { CabinID = cabinIDToAddCounselorTo, CounselorID = counselor.CounselorID});
                                            db.Counselors.Add(counselor);
                                            try
                                            {
                                                db.SaveChanges();

                                                Console.WriteLine($"Counselor has been assinged to cabin number: {cabinNumberToAddCounselorTo}");
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }

                                        }

                                        break;
                                    }
                                case 2:
                                    {
                                        var counselor = UserInputs.GetACounselorToAdd();

                                        using (var db = new CampSleepAwayContext())
                                        {
                                            db.Counselors.Add(counselor);
                                            try
                                            {
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Does counselors social security number already in database? Contact support if the problem persists.");
                                            }

                                        }

                                        break;
                                    }
                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 11: //Update Exsisting Counselor DONE
                        {

                            PrintTextToConsole.CounselorMenuSSN();
                            int counselorSSN = UserInputs.GetSSN();
                            var counselorToUpdate = new Counselor();

                            using (var db = new CampSleepAwayContext())
                            {

                                try
                                {
                                    counselorToUpdate = db.Counselors.Where(C => C.SocialSecurityNumber == counselorSSN).FirstOrDefault<Counselor>();
                                }
                                catch
                                {
                                    Console.WriteLine("The counselor in question could not be found.");
                                    PrintTextToConsole.ReturnToMainMenu();
                                    break;
                                }

                                PrintTextToConsole.CounselorMenuAttribute();
                                int userUpdateCounselorChoice = UserInputs.GetOneToSix();

                                switch (userUpdateCounselorChoice)
                                {
                                    case 1:
                                        {
                                            counselorToUpdate.FirstName = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);
                                                db.CounselorHistories.Add(counselorHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            counselorToUpdate.LastNAme = UserInputs.GetNotNullStringInput();
                                            try
                                            {
                                                db.SaveChanges();

                                                var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);
                                                db.CounselorHistories.Add(counselorHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            counselorToUpdate.PhoneNumber = UserInputs.GetPhoneNumber();
                                            try
                                            {
                                                db.SaveChanges();

                                                var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);
                                                db.CounselorHistories.Add(counselorHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            counselorToUpdate.SocialSecurityNumber = UserInputs.GetSSN();
                                            try
                                            {
                                                db.SaveChanges();

                                                var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);

                                                db.CounselorHistories.Add(counselorHistory);
                                                db.SaveChanges();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Error when saving to database. Please contact support if the problem persists.");
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            PrintTextToConsole.UpdateCounselorCabinMenu();
                                            int updateCounselorCabinMenuChoice = UserInputs.GetOneToTwo();

                                            switch (updateCounselorCabinMenuChoice)
                                            {
                                                case 1:
                                                    {
                                                        PrintTextToConsole.AssignCounselorToCabin();
                                                        int userAssignCounselorToCabinNumberChoice = UserInputs.GetATrueIntNumber();

                                                        try
                                                        {
                                                            var cabinToAssginCounselorTo = db.Cabins.Where(C => C.CabinNumber == userAssignCounselorToCabinNumberChoice).FirstOrDefault<Cabin>();

                                                            try
                                                            {
                                                                var cabinsCounselor = db.CabinsCounselors.Where(CC => CC.CabinID == cabinToAssginCounselorTo.CabinID).FirstOrDefault<CabinsCounselor>();
                                                                
                                                            }
                                                            catch
                                                            {
                                                                Console.WriteLine("The cabin is already occupied");
                                                                break;
                                                            }

                                                            var cabinsCounselorToRemove = db.CabinsCounselors.Where(CC => CC.CounselorID == counselorToUpdate.CounselorID).FirstOrDefault<CabinsCounselor>();

                                                            var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);

                                                            try
                                                            {
                                                                db.CabinsCounselors.Remove(cabinsCounselorToRemove);
                                                            }
                                                            catch
                                                            { 
                                                            
                                                            }

                                                            db.CounselorHistories.Add(counselorHistory);
                                                            db.SaveChanges();

                                                            db.CabinsCounselors.Add(new CabinsCounselor() { Cabin = cabinToAssginCounselorTo, Counselor = counselorToUpdate });
                                                            db.SaveChanges();

                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when acesssing database, is the cabin occupied or nonexsisting? Please contact support if the problem persists");
                                                        }


                                                        break;
                                                    }
                                                case 2:
                                                    {


                                                        try
                                                        {
                                                            var cabinsCounselor = db.CabinsCounselors.Where(CC => CC.CounselorID == counselorToUpdate.CounselorID).FirstOrDefault<CabinsCounselor>();

                                                            var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);

                                                            db.CounselorHistories.Add(counselorHistory);
                                                            db.SaveChanges();

                                                            db.CabinsCounselors.Remove(cabinsCounselor);
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when acesssing database, does the counselor have an assigned cabin? Please contact support if the problem persists");
                                                        }
                                                        

                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            PrintTextToConsole.PrintRemoveCounselorMenu(counselorToUpdate);

                                            int userRemoveNextOfKinMenuChoice = UserInputs.GetOneToTwo();

                                            switch (userRemoveNextOfKinMenuChoice)
                                            {
                                                case 1:
                                                    {
                                                        var cabinsCounselor = db.CabinsCounselors.Where(CC => CC.CounselorID == counselorToUpdate.CounselorID).FirstOrDefault<CabinsCounselor>();

                                                        var counselorHistory = HelpMethods.GetACounselorHistory(counselorToUpdate);

                                                        counselorHistory.CabinID = null;
                                                        
                                                        try
                                                        {
                                                            db.CabinsCounselors.Remove(cabinsCounselor);
                                                            db.Counselors.Remove(counselorToUpdate);
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when removing counselor. Please contact support if the problem persists.");
                                                        }

                                                        db.CounselorHistories.Add(counselorHistory);

                                                        try
                                                        {
                                                            db.SaveChanges();
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error when adding to counselor history. Please contact support if the problem persists.");
                                                        }

                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            break;
                                        }
                                }

                            }

                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                    case 12: //Exit the program DONE
                        {
                            stayInMainMenu = false;
                            PrintTextToConsole.ExitFromMainMenu();
                            break;
                        }
                    case 99: //Admin Menu 
                        {
                            PrintTextToConsole.AdminMenu();
                            bool sucessfullPasswordInput = UserInputs.GetCorrectPassword();
                            if (sucessfullPasswordInput)
                            {
                                //Run methods where admin can delete from history tables and remove/add/generate cabins. Password = 1234
                            }
                            PrintTextToConsole.ReturnToMainMenu();
                            break;
                        }
                }
            }

        }



        public void RunMainTesting()
        {
            Console.WriteLine("Adding Counselors");
            using (var db = new CampSleepAwayContext())
            {
                var counselor1 = new Counselor() { FirstName = "Anton", LastNAme = "Asplund", PhoneNumber = 0702895997, SocialSecurityNumber = 8802225 };
                var counselor2 = new Counselor() { FirstName = "Sara", LastNAme = "Karlsson", PhoneNumber = 0709488770, SocialSecurityNumber = 880726 };

                db.Counselors.Add(counselor1);
                db.Counselors.Add(counselor2);
                db.SaveChanges();
            }

            Console.WriteLine("Adding Campers");
            using (var db = new CampSleepAwayContext())
            {
                var camper1 = new Camper() { FirstName = "Hugo", LastName = "Asplund", SocialSecurityNumber = 140204 };
                var camper2 = new Camper() { FirstName = "Stina", LastName = "Asplund", SocialSecurityNumber = 161105 };

                db.Campers.Add(camper1);
                db.Campers.Add(camper2);
                db.SaveChanges();
            }

            Console.WriteLine("Adding NextOfKin");
            using (var db = new CampSleepAwayContext())
            {
                var nextofkin = new NextOfKin() { FirstName = "Robert", LastName = "Asplund", PhoneNumber = 0340678379, SocialSecurtyNumber = 520814, CamperID = db.Campers.FirstOrDefault(C => C.FirstName == "Hugo").CamperId };


                db.NextOfKins.Add(nextofkin);
                db.SaveChanges();
            }

            Console.WriteLine("Adding Campers to Cabin");
            using (var db = new CampSleepAwayContext())
            {
                var camper = db.Campers.FirstOrDefault(C => C.FirstName == "Hugo");
                var camper2 = db.Campers.FirstOrDefault(C => C.FirstName == "Stina");

                var cabin = db.Cabins.FirstOrDefault(C => C.CabinNumber == 1);

                cabin.FreeCamperBunks += (-1);
                camper.CabinID = cabin.CabinID;
                cabin.FreeCamperBunks += (-1);
                camper2.CabinID = cabin.CabinID;

                var cabinCounselor = new CabinsCounselor();
                cabinCounselor.CounselorID = db.Counselors.FirstOrDefault(C => C.FirstName == "Anton").CounselorID;
                cabinCounselor.CabinID = cabin.CabinID;

                db.CabinsCounselors.Add(cabinCounselor);

                db.SaveChanges();
            }

            Console.WriteLine("Testing new stuff");
            using (var db = new CampSleepAwayContext())
            {
                var camper = db.Campers.FirstOrDefault(C => C.FirstName == "Hugo");

                var nextOfKin2 = new NextOfKin() { FirstName = "Gunnel", LastName = "Asplund", PhoneNumber = 0706873156, SocialSecurtyNumber = 561110 };
                var nextOfKin3 = new NextOfKin() { FirstName = "Moa", LastName = "Asplund", PhoneNumber = 0706655445, SocialSecurtyNumber = 920926 };

                camper.NextOfKins.Add(nextOfKin2);
                camper.NextOfKins.Add(nextOfKin3);

                db.SaveChanges();
            }
        }



    }
}
