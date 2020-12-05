using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Library
{
    /*  DevTeams need   :
     *                      1 Team members (Developer name, ID number from Developer class)
     *                      2 Team name string
     *                      3 Team ID int
     *                      
     *                      */


    // public enum ??
    public class DevTeam : Developer // inherit developer properties
    {
        public string TeamName { get; set; }
        public int TeamNumber { get; set; }

        public List<Developer> TeamMembers { get; set; } = new List<Developer>();
        public DevTeam() { } // overload constructor

        public DevTeam(string teamName, int teamNumber, List<Developer> teamMembers)
        {
            TeamName = teamName;
            TeamNumber = teamNumber;
            TeamMembers = teamMembers; 
            

        }


    }
}
