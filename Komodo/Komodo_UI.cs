using Komodo;
using Komodo_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo
{
    /*                            
     *                             Menu :
     *                             1- View list of developers
     *                             2- view list of devteams
     *                             3- view teams w/ members
     *                             
     *                             4- add d or t
     *                             5- delete d or t
     *                             6- update d or t
     *                             
     *                             7- MGR add D to T
     *                             
     *                             8- HR view D needing PS access
     *                             9- Exit
     *                             **/

    class Komodo_UI
    {
        // create private repositories (like top class in Repo files)

        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();




        // method that runs / starts UI of application
        public void Run()
        {
            SeedDeveloperList();
            SeedDevTeamList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true; // while loop to keep menu running
            while (keepRunning)
            {


                // Display Options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1 View list of Developers\n" +
                    "2 View list of DevTeams\n" +
                    "3 View DevTeam rosters\n" +
                    "4 Add Developer or DevTeam by ID Number\n" +
                    "5 Update Developer or DevTeam by ID Number\n" +
                    "6 Delete Developer or DevTeam by ID Number\n" +
                    "7 Add Developers to Team\n" +
                    "8 (HR) View list of Developers needing PluralSight access\n" +
                    "9 Exit");


                // Get user input

                string input = Console.ReadLine();


                // Evaluate user input & act accordingly

                switch (input)

                {
                    /* 1- View list of developers
     *                             2- view list of devteams
     *                             3- view teams w/ members
     *                             
     *                             4- add d or t
     *                             5- update d or t
     *                             6- delete d or t
     *                             
     *                             7- MGR add D to T
     *                             
     *                             8- HR view D needing PS access
     *                             9- Exit
     *                             **/

                    case "1": //View list of developers
                        ShowListofDevs();
                        break;


                    case "2": //View list of devteams
                        ShowListOfTeams();
                        break;


                    case "3": //View DevTeam rosters
                        ShowListOfTeamsWDevelopers();
                        break;

                    case "4": //Add developer or team

                        Console.Clear();
                        Console.WriteLine("To add new DEVELOPER, Press D, or to add new TEAM, Press T."); //Enter D/T
                        var selection1 = Console.ReadKey().Key;
                        Console.Clear();
                        if (selection1 == ConsoleKey.D)
                        {
                            CreateNewDeveloper();
                            break;
                        }
                        else if (selection1 == ConsoleKey.T)
                        {
                            CreateNewDevTeam();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid selection. Press any key to continue");
                            Console.ReadKey();
                            goto case "4";

                        }


                    case "5": //Update developer or team
                        Console.Clear();
                        Console.WriteLine("To update a DEVELOPER, Press D, or to update a TEAM, Press T."); //Enter D/T
                        var selection3 = Console.ReadKey().Key;
                        Console.Clear();
                        if (selection3 == ConsoleKey.D)
                        {
                            UpdateDev();
                            break;
                        }
                        else if (selection3 == ConsoleKey.T)
                        {
                            UpdateTeam();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid selection. Press any key to continue");
                            Console.ReadKey();
                            goto case "5";

                        }

                        

                    case "6": // Delete d or t

                        Console.Clear();
                        Console.WriteLine("To delete DEVELOPER, Press D, or to delete TEAM, Press T."); //Enter D/T
                        var selection2 = Console.ReadKey().Key;
                        if (selection2 == ConsoleKey.D)
                        {
                            DeleteDev();
                            break;
                        }
                        else if (selection2 == ConsoleKey.T)
                        {
                            DeleteDevTeam();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid selection. Press any key to continue");
                            Console.ReadKey();
                            goto case "6";

                        }

                    case "7": // Add D to T
                        AddDevToTeamById();
                        break;



                    case "8": // View D needing PS access
                        ShowListDevsWOutPSAccess();
                        break;

                    case "9": //exit
                        Console.WriteLine("Press any key to exit to menu ...");
                        Console.ReadKey();
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid selection:");
                        break;
                }
                
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear(); // clear screen while running
                
            }
        }

        // Create New Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();

            Developer newDeveloper = new Developer();

            // Last Name
            Console.WriteLine("Enter Developer LAST Name:");
            newDeveloper.LastName = Console.ReadLine();

            // First Name
            Console.WriteLine("Enter Developer FIRST Name:");
            newDeveloper.FirstName = Console.ReadLine();

            // Id Number Int 
            Console.WriteLine("Enter Developer 3 Digit ID Number:");
            var idInput = Console.ReadLine();
            newDeveloper.IDNumber = Convert.ToInt32(idInput);

            // PluraSight Access Bool
            Console.WriteLine("Does Developer have access to PluralSight?\n" +
                " Enter Y if so, othewise hit any key.");
            var psInput = Console.ReadLine().ToUpper();
            if (psInput == "Y")
            {
                newDeveloper.PluralSightAccess = true;
            }
            else
            {
                newDeveloper.PluralSightAccess = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
            


        }
        // Create New Team
        private void CreateNewDevTeam()
        {
            Console.Clear();

            DevTeam newTeam = new DevTeam();

            //Team Name
            Console.WriteLine("Enter Team Name:");
            newTeam.TeamName = Console.ReadLine();

            //Team ID number
            Console.WriteLine("Enter team 3 digit ID number:");
            var idInput = Console.ReadLine();
            newTeam.TeamNumber = Convert.ToInt32(idInput);

            _devTeamRepo.AddTeamToListOfTeams(newTeam);
        }

        //Delete Developer
        private void DeleteDev()
        {
            Console.Clear();
            ShowListofDevs();

            Console.WriteLine("Enter the ID Number of the Developer you would like to delete: ");
            int input = Convert.ToInt32(Console.ReadLine());

            _developerRepo.RemoveDeveloperFromList(input);


        }

        //Delete DevTeam
        private void DeleteDevTeam()

        {
            Console.Clear();
            ShowListOfTeams();
            Console.WriteLine("Enter the ID Number of the DevTeam you would like to delete: ");
            int input = Convert.ToInt32(Console.ReadLine());

            _devTeamRepo.RemoveTeamFromListByTeamNumber(input); 
        }

        private void UpdateDev()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            Console.Clear();
            ShowListofDevs();

            Console.WriteLine("Please enter the ID Number for the Developer you would like to update:");
            int input = Convert.ToInt32(Console.ReadLine());
            
            Developer newDeveloper = new Developer();

            _developerRepo.UpdateExistingDeveloperByIdNumber(input, newDeveloper);
            newDeveloper.IDNumber = input;

            Console.WriteLine("Please enter Developer's LAST name: ");
            newDeveloper.LastName = (Console.ReadLine());

            Console.WriteLine("Please enter Developer's FIRST name: ");
            newDeveloper.FirstName = (Console.ReadLine());

            Console.WriteLine("Does Developer have PluralSight access? Y/N ");
            var psInput = Console.ReadLine().ToUpper();
            if (psInput == "Y")
            {
                newDeveloper.PluralSightAccess = true;
                _developerRepo.AddDeveloperToList(newDeveloper);
            }
            else
            {
                newDeveloper.PluralSightAccess = false;
                _developerRepo.AddDeveloperToList(newDeveloper);
            }



        }

        private void UpdateTeam()
        {
            
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetListOfDeveloperTeams();

            Console.Clear();
            ShowListOfTeams();

            Console.WriteLine("Please enter the ID Number for the Team you would like to update:");
            int input = Convert.ToInt32(Console.ReadLine());

            DevTeam newDevTeam = new DevTeam();

            _devTeamRepo.UpdateExistingTeamByIdNumber(input, newDevTeam);
           
            newDevTeam.TeamNumber = input;

            Console.WriteLine("Please enter Team name: ");
            newDevTeam.TeamName = (Console.ReadLine());

            _devTeamRepo.AddTeamToListOfTeams(newDevTeam);

        }

        //Add Dev to DevTeam by Dev ID Number
        private void AddDevToTeamById()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            List<DevTeam> listOfTeams = _devTeamRepo.GetListOfDeveloperTeams();

            Console.Clear();
            Console.WriteLine("Press any key to see a list of DEVELOPERS and TEAMS:");
            Console.ReadKey();

            ShowListofDevs();
            ShowListOfTeams();
           
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Would you like to add a Developer to a DevTeam? Y/N ");
                var input = Console.ReadLine().ToUpper();
               

                if (input == "Y")
                { 
                Console.WriteLine("Enter a TEAM ID Number to add Developer: ");
                var userInputeTeamID = Console.ReadLine();
                Console.WriteLine("Enter a DEVELOPER ID Number to add to Developer Team: ");
                var userInputDeveloperID = Console.ReadLine();

                int intInputTeamID = Convert.ToInt32(userInputeTeamID);
                int intInputDeveloperID = Convert.ToInt32(userInputDeveloperID);

                // Find the developer

                Developer addDeveloper = new Developer();
                addDeveloper = _developerRepo.GetDeveloperByIdNumber(intInputDeveloperID);

                // Find team by ID (not needed)
                // _devTeamRepo.GetDevTeamByNumber(intInputTeamID);

                // Add developer line 280 to team with team id

                _devTeamRepo.AddDeveloperToTeam(intInputTeamID, addDeveloper);

                }
                
                else if (input == "N")
                {
                    Console.WriteLine("Exiting from Add Developer to DevTeam...");
                    keepRunning = false;

                }

                else
                {
                    Console.WriteLine("Please enter a valid selection: Y or N");

                }


            }
        }
        //Remove Dev from DevTeam by Dev ID Number
        private void RemoveDevFromTeamById()
        {

        }

        //Show list of Devs 
        private void ShowListofDevs()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"ID Number: {developer.IDNumber} : {developer.LastName}, {developer.FirstName}");
                if (developer.PluralSightAccess == true)
                {
                    Console.WriteLine("CURRENT PluralSight Access");
                    
                }
                else
                {
                    Console.WriteLine("Needs PluralSight Access");
                }
            }

        }

        // Show list of DevTeams only (w/out roster)
        private void ShowListOfTeams()
        {

            List<DevTeam> listOfTeams = _devTeamRepo.GetListOfDeveloperTeams();
            foreach (DevTeam devTeam in listOfTeams)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamNumber} // Team Name : {devTeam.TeamName}");
            }

        }


        // SHow list of team w/ developers
        private void ShowListOfTeamsWDevelopers()
        {

            List<DevTeam> listOfTeams = _devTeamRepo.GetListOfDeveloperTeams();

            Console.WriteLine("Press any key to see a list of DEVTEAMS with Team Members ... ");
            Console.ReadKey();



            foreach (DevTeam devTeam in listOfTeams)
            {
                Console.WriteLine($"Team ID Number: {devTeam.TeamNumber} // Team Name: {devTeam.TeamName}");

                foreach (Developer developer in devTeam.TeamMembers)
                {
                    Console.WriteLine($"ID Number: {developer.IDNumber} : {developer.LastName}, {developer.FirstName} ");
                }
            }

        }


        // Udate list of devs needs PS access
        private void ShowListDevsWOutPSAccess()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            Console.WriteLine("The following developers do not have PluralSight Access:");
            foreach (Developer developer in listOfDevelopers)
            {
                if (developer.PluralSightAccess == false)
                {
                    Console.WriteLine($"ID Number: {developer.IDNumber} : {developer.LastName}, {developer.FirstName}\n" +
                        $" ");

                }

                else
                { }

            }

            bool keepRunning = true; // while loop to keep update process running
            while (keepRunning)
            {

                Console.WriteLine("Would you like to update the status of PluralSight Access? Y/N");
                var input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "Y":
                        Console.Clear();
                        ShowListofDevs();
                        Console.WriteLine("Enter ID Number: ");

                        var inputID = Console.ReadLine();
                        int originalIdNumber = Convert.ToInt32(inputID);


                        Developer newDeveloper = new Developer();


                        _developerRepo.UpdateExistingDeveloperForPluralSightAccessByIdNumber(originalIdNumber, newDeveloper);
                        newDeveloper.IDNumber = originalIdNumber;

                        Console.WriteLine("Does Developer have PluralSight Access? Y/N");
                        var accessInput = Console.ReadLine().ToUpper();

                        if (accessInput == "Y")
                        {
                            newDeveloper.PluralSightAccess = true;
                            
                             _developerRepo.AddDeveloperToList(newDeveloper);
                        }
                        else
                        {
                            newDeveloper.PluralSightAccess = false;
                            _developerRepo.AddDeveloperToList(newDeveloper);
                        }

                        break;

                    case "N":
                        Console.WriteLine("No changes will be made.");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selection : Y/N");
                        break;


                }

                /* if (input == "Y")
                 {
                     Console.Clear();
                     ShowListofDevs();
                     Console.WriteLine("Enter ID Number: ");

                     var inputID = Console.ReadLine();
                     int originalIdNumber = Convert.ToInt32(inputID);


                     Developer newDeveloper = new Developer();


                     _developerRepo.UpdateExistingDeveloperForPluralSightAccessByIdNumber(originalIdNumber, newDeveloper);
                     newDeveloper.IDNumber = originalIdNumber;

                     Console.WriteLine("Does Developer have PluralSight Access? Y/N");
                     var accessInput = Console.ReadLine().ToUpper();
                     if (accessInput == "Y")
                     {
                         newDeveloper.PluralSightAccess = true;
                     }
                     else
                     {
                         newDeveloper.PluralSightAccess = false;
                     }




                 }
                 else if (input == "N")
                 {
                     Console.WriteLine("No changes will be made.");
                     keepRunning = false;
                 }
                 else
                 {
                     Console.WriteLine("Please enter a valid selection : Y/N");

                 }
                */
            }
        }

        // add multiple devs to team
        private void AddMultipleDevsToTeam()
        {

        }

        //Seed method
        private void SeedDeveloperList()
        {
            Developer michael = new Developer("Scott", "Michael", 100, false);
            Developer jim = new Developer("Halpert", "Jim", 111, true);
            Developer pam = new Developer("Beesly", "Pam", 222, true);
            Developer dwight = new Developer("Schrute", "Dwight", 333, false);
            Developer andy = new Developer("Bernard", "Andy", 444, false);
            Developer phyllis = new Developer("Vance", "Phyllis", 555, false);
            Developer stanley = new Developer("Hutchinson", "Stanley", 666, true);
            Developer kelly = new Developer("Kapur", "Kelly", 777, false);
            Developer ryan = new Developer("Howard", "Ryan", 888, true);
            Developer creed = new Developer("Bratton", "Creed", 999, false);

            _developerRepo.AddDeveloperToList(michael);
            _developerRepo.AddDeveloperToList(jim);
            _developerRepo.AddDeveloperToList(pam);
            _developerRepo.AddDeveloperToList(dwight);
            _developerRepo.AddDeveloperToList(andy);
            _developerRepo.AddDeveloperToList(phyllis);
            _developerRepo.AddDeveloperToList(stanley);
            _developerRepo.AddDeveloperToList(kelly);
            _developerRepo.AddDeveloperToList(ryan);
            _developerRepo.AddDeveloperToList(creed);

        }

        private void SeedDevTeamList()
        {
            DevTeam Blue = new DevTeam("Blue", 123, new List<Developer>());
            DevTeam Red = new DevTeam("Red", 234, new List<Developer>());
            DevTeam Green = new DevTeam("Green", 345, new List<Developer>());



            _devTeamRepo.AddTeamToListOfTeams(Blue);
            _devTeamRepo.AddTeamToListOfTeams(Red);
            _devTeamRepo.AddTeamToListOfTeams(Green);

        }
    }
}
