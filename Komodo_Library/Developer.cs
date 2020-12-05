using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Library
{

    /* 
     * Developers need : 
     *                  1 Names strings
     *                  2 ID numbers int
     *                  3 bool Pluralsight access y/n
     *                  
     *                  */


    // POCO

    // maybe add enum for team? & start = 1
    public class Developer 
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int IDNumber { get; set; }
        public bool PluralSightAccess { get; set; }

        public Developer() { } // overloaded developer constructor

        public Developer(string lastName, string firstName, int idNumber, bool pluralSightAccess)
        {
            LastName = lastName;
            FirstName = firstName;
            IDNumber = idNumber;
            PluralSightAccess = pluralSightAccess;
                
        }
    }

    


    
}
