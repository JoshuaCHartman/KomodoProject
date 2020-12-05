using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Library
{/*                            1 Get list of Developers
  *                            2 Get list of Developers w/ Team assignments
  *                            3 Get list of DevTeams
  *                             
  *                            4 Add new Dev
  *                            5 Delete Dev
  *                            6 Add new DevTeam
  *                            7 Delete DevTeam
  *                             
  *                            8 Get list of Developers needing Pluralsight access (HR)
  *                             
  *                            9 Add Developer to DevTeam by developer ID number
  *                            10 Remove Developer from DevTeam by Developer ID Number
  *                             
  *                            11 Add multiple Developers to Team
  *                             
  *                            12 Exit
  *                             
  *                 
         *                      */

    public class DevTeamRepo
    {
        private List<DevTeam> _listOfDeveloperTeams = new List<DevTeam>(); //create field to use in CRUD



        //CRUD

        // CREATE - add team to list of teams

        public void AddTeamToListOfTeams(DevTeam devTeam)
        {
            _listOfDeveloperTeams.Add(devTeam); //add new object "devTeam" in class "DevTeam" to existing list of teams, no return
        }

        // // CREATE - add DEVELOPER to TEAM
        public void AddDeveloperToTeam(int teamNumber, Developer developer)
        {
            DevTeam teamName = GetDevTeamByNumber(teamNumber);
            teamName.TeamMembers.Add(developer);

        }

        // READ - return existing list of Developer Teams
        public List<DevTeam> GetListOfDeveloperTeams() //returning list
        {
            return _listOfDeveloperTeams;
        }



        // UPDATE
        public bool UpdateExistingTeamByIdNumber(int originalIdNumber, DevTeam newDevTeam)
        {
            //Find the DevTeam
            DevTeam oldDevTeam = GetDevTeamByNumber(originalIdNumber);

            //Update the DevTeam
            if (oldDevTeam != null)
            {
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.TeamNumber = newDevTeam.TeamNumber;

                _listOfDeveloperTeams.Remove(oldDevTeam);

                return true;
                
            }
            else
            {
                return false;
            }
        }



        // DELETE

        // Delete by Team Number
        public bool RemoveTeamFromListByTeamNumber(int teamNumber)
        {
            DevTeam devTeam = GetDevTeamByNumber(teamNumber);

            if (devTeam == null)
            {
                return false; // RETURN FALSE if cannot find team by team NUMBER
            }

            int initialCountOfTeams = _listOfDeveloperTeams.Count; //count number of entries on list, make it new int
            _listOfDeveloperTeams.Remove(devTeam); //remove from list

            if (initialCountOfTeams > _listOfDeveloperTeams.Count)
            {
                return true; // verifies team removed bc original count higher than current
            }
            else
            {
                return false; // shows no change in count of teams

            }
        }
            
            // Delete by Team Name
        public bool RemoveTeamFromListByName(string teamName)
        {
            DevTeam devTeam = GetDevTeamsByTeamName(teamName);

            if (devTeam == null)
            {
                return false; //False = can't find team by team NAME
            }
            
            int initialCountOfTeams = _listOfDeveloperTeams.Count; 
            _listOfDeveloperTeams.Remove(devTeam);

            if (initialCountOfTeams > _listOfDeveloperTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // HELPER METHODS

        public DevTeam GetDevTeamsByTeamName(string teamName)
        {
            foreach (DevTeam individualTeam in _listOfDeveloperTeams)
            {
                if (individualTeam.TeamName == teamName)
                {
                    return individualTeam;
                }
                
            }
            return null;
        }

        public DevTeam GetDevTeamByNumber(int teamNumber)
        {
            foreach (DevTeam individualTeam in _listOfDeveloperTeams)
            {
                if (individualTeam.TeamNumber == teamNumber)
                {
                    return individualTeam;
                }
            }
            return null;

        }
    }
}
