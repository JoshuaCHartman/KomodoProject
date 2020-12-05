using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Library
{/*                             1 Get list of Developers needing Pluralsight access by HR
         *                      2 Get list of Developers (w/ team assignments)
         *                      3 Get list of DevTeams
         *                      4 Add / remove Developers to DevTeams by ID number
         *                      5 Make new DevTeam
         *                      6 exit
         *                      
         *                      Option to add multiple Developers to DevTeam at once
         *                      */

    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>(); //create field to use in CRUD 


        //CRUD 

        //Create (add content to list : add developer to list)
        public void AddDeveloperToList(Developer developer) //add only - not return, so void is return type
        {
            _listOfDevelopers.Add(developer);

        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //Update
            // UPDATE by ID Number
        public bool UpdateExistingDeveloperByIdNumber(int originalIdNumber, Developer newDeveloper)
        {
            //Find the Developer
            Developer oldDeveloper = GetDeveloperByIdNumber(originalIdNumber);

            //Update the Developer
            if (oldDeveloper != null)
            {
                oldDeveloper.IDNumber = newDeveloper.IDNumber;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.PluralSightAccess = newDeveloper.PluralSightAccess;

                _listOfDevelopers.Remove(oldDeveloper);

                return true;
            }
            else
            {
                return false;
            }
        }
            // UPDATE by PluralSightAccess
        public bool UpdateExistingDeveloperForPluralSightAccessByIdNumber (int originalIdNumber, Developer newDeveloper)
        {
               // Find the Developer
            Developer oldDeveloper = GetDeveloperByIdNumber(originalIdNumber);

               // Update the Developer
               if (oldDeveloper != null)
            {
                oldDeveloper.IDNumber = newDeveloper.IDNumber;
                newDeveloper.FirstName = oldDeveloper.FirstName;
                newDeveloper.LastName = oldDeveloper.LastName;
                oldDeveloper.PluralSightAccess = newDeveloper.PluralSightAccess;

                _listOfDevelopers.Remove(oldDeveloper);

                return true;
            }
            else
            {
                return false;
            }
        }

            // UPDATE by Last Name
        public bool UpdateExistingDeveloperByLastName (string originalLastName, Developer newDeveloper)
        {
            // Find the Developer

            Developer oldDeveloper = GetDeveloperByLastName(originalLastName);

            // Update the Developer
           
            if (oldDeveloper != null)
            {
                oldDeveloper.IDNumber = oldDeveloper.IDNumber;
                oldDeveloper.FirstName = oldDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.PluralSightAccess = oldDeveloper.PluralSightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete

        public bool RemoveDeveloperFromList(int idNumber)
        {
            Developer developer = GetDeveloperByIdNumber(idNumber);

            if (developer == null)
            {
                return false; // returns false if cannot find developer by IDnumber in list of developers
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Methods (get developers by last name, ID number, or PluralSightAccess)
        public Developer GetDeveloperByLastName(string lastName)
        {
            foreach (Developer individualDeveloper in _listOfDevelopers)
            {
                if (individualDeveloper.LastName == lastName)
                {
                    return individualDeveloper;
                }

            }

            return null;
        }

        public Developer GetDeveloperByIdNumber(int idNumber)
        {
            foreach (Developer individualDeveloper in _listOfDevelopers)
            {
                if (individualDeveloper.IDNumber == idNumber)
                {
                    return individualDeveloper;
                }
            }

            return null;

        }

        public Developer GetDeveloperByPluralSightAccess(bool pluralSightAccess)
        {
            foreach (Developer individualDeveloper in _listOfDevelopers)
            {
                if (individualDeveloper.PluralSightAccess == true)
                {
                    return individualDeveloper;
                }
            }
            return null;

        }

    }
}
