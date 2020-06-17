using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ListOfCustomClass
{
    class Person // this class will throw a warning error if GetHaschCode isn't implemented
    {
        // fields
        private readonly DateTime _dateTime = DateTime.Now;
        

        // properties
        public string Fullname
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int BirthYear { get; set; }
        public string Age { get; set; }

        // methods
        public void CalculateAge(int birthYear)
        {
            BirthYear = birthYear;
            int currentYear = Convert.ToInt32(_dateTime.Year);
            Age = Convert.ToString(currentYear - birthYear);
        }

        public static void PickAPerson(Person person)
        {
            Console.WriteLine($"The selected index for the People list is containing {person}");
        }

        public static void PickAPerson(int index, List<Person> person)
        {
            Console.WriteLine(person[index]);
        }

        /* To override the comparison of two objects with particular entity by accessing its members.
         * using Equals override method to further comparing two objects using Age properties (not just object 1 vs object 2, which is always 2 different things).
         * we use the Age properties, which we can entered for example below. */
        public override bool Equals(object obj)
        {
            if (Age == ((Person)obj).Age) // we cast object to type Person so it can access it's properties/members
            {
                return true;
            }
            return false;
        }

        /* Creating GetHashCode override method to avoid warning error on the class as we have declare an overide method for
         * the Equals method above */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static string FindPerson (List<Person> people, string firstName) // take in a people list, & user input for 1st name.
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].FirstName.Equals(firstName))
                {
                    return "There is a match! >> " + people[i].ToString();
                }
            }

            return "Cannot find the first name of " + firstName;
        }

        public static string FindPerson(List<Person> people, Person person) // FindPerson overload to be able to pass in Person object
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Equals(person))
                {
                    return "👍👍 There is a match! >> " + people[i].ToString() + " is the same age as " + person;
                }
            }

            return "👎🏽👎🏽 No same name";
        }

        /* One way to look over the people list to search for each person with certain age.
         * */
        public static void FindAge(List<Person> people, string age)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (age.Equals(people[i].Age))
                {
                    Console.WriteLine("Result found: " + people[i]); 
                }
            }

            Console.WriteLine(">>>>> End of Search <<<<<"); 
        }

        /* This is an example of a method where it returns custom type object.
         * see we are returning 'Person' type for this method. */
         public static Person FindBirthYear(List<Person> people, string year) // See we're using Person type in the method.
        {
            return null;
        }
        public override string ToString()
        {
            return "Fullname: " + Fullname + " >>> Age: " + Age;
        }
    }
}
