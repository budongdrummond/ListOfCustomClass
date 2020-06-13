namespace ListOfCustomClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            Console.WriteLine("Hello World! start of Caleb Curry Video #71");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            List<Person> people = new List<Person>();

            // instance of Person > person1 object
            var person1 = new Person();
            person1.FirstName = "Budong";
            person1.SecondName = "Drummond";
            Console.WriteLine($"Hi, {person1.FirstName}, Enter the year you are born in:");
            int birthYear = Convert.ToInt32(Console.ReadLine());
            person1.CalculateAge(birthYear);
            Console.WriteLine($"So I know you are now {person1.Age} years old");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            // another instance of Person > person2 object. Alternative simplified was to create and set names.
            var person2 = new Person { FirstName = "Clare", SecondName = "Carney" };
            Console.WriteLine($"Hi, {person2.FirstName}, Enter the year you are born in:");
            int birthYear2 = Convert.ToInt32(Console.ReadLine());
            person2.CalculateAge(birthYear2);
            Console.WriteLine($"So I know you are now {person2.Age} years old");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            people.Add(person1);
            people.Add(person2);

            /* Adding or filling value as a custome type inside a loop. e.g., asking user in cosole to add value in the loop
             * you can create user as many as you want it, alternatively, reading from a file, 
             * putting everything in the object and add it to the list.
             */

            // keep asking user until exit is chosen
            bool KeepGoing = true;
            do
            {
                // Using switch statement to add more user or not, via console.                
                Console.WriteLine("Do you want to add more user? insert Y or N & press [ENTER]:");
                string userAddMoreUserInput = Console.ReadLine().ToLower();
                String[] FirstAndSecondName = new String[2];
                switch (userAddMoreUserInput)
                {
                    case "y":
                        Console.WriteLine("Enter the fullname seperated by a space: ");

                        // read full name, convert all names to lower case
                        string UserFullName = Console.ReadLine().ToLower();

                        // set what is the seperators characters between 1st & 2nd name
                        /* String[] Seperator = { " ", ",", "" }; */
                        string separator = " ";

                        // split the fullname into 2 and store in in new string array. removed any empty spaces.
                        /* String[] FirstAndSecondName = UserFullName.Split(Seperator, 2, StringSplitOptions.RemoveEmptyEntries); */

                        // split the fullname into 2 and store in in new string array FirstAndSecondName via names to avoid error
                        string[] names = UserFullName.Split(separator); // using names array to avoid error here
                        // if there are more than 1 name entered assign to FirstAndSecondName, else if, only 1 name entered - insert space for 2nd name
                        if (names.Length > 1)
                        {
                            for (int i = 0; i < FirstAndSecondName.Length; i++)
                            {
                                FirstAndSecondName[i] = names[i];
                            }
                        }
                        else if (names.Length == 1)
                        {
                            FirstAndSecondName[0] = names[0];
                            FirstAndSecondName[1] = " ";
                        }
                        var NewPerson = new Person { FirstName = FirstAndSecondName[0], SecondName = FirstAndSecondName[1] }; // add 1st & 2nd name taken from String array

                        Console.WriteLine("Enter the year you are born in:");
                        int UserBirthYear = Convert.ToInt32(Console.ReadLine());

                        NewPerson.CalculateAge(UserBirthYear); // calculate age from given birth year.
                        people.Add(NewPerson); // add new person to people List
                        break;
                    case "n":
                        Console.WriteLine("Finished with adding more people\n");
                        KeepGoing = false;
                        break;
                    default:
                        break;
                }
            } while (KeepGoing);

            /* An example of one liner for the same result on creating list and assign person1 & person2:
             * List<Person> people = new List<Person>(){person1, person2};
             */
            Console.WriteLine($"Currently, there are {people.Count} people in the list:");

            // Iterate the people List
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            /* >>>>> List<Person> people = new List<Person>(); <<<<<
               is the list we are working on in this Main method.*/

            // Passing custom type into method - Video 73.
            Console.WriteLine("Insert the index of the person you want to pick from people list:");
            int index = Convert.ToInt32(Console.ReadLine());
            Person.PickAPerson(people[index]);

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            // Static Method(Method to Take an ArrayList of Custom Type) - Video 76.
            Person.PickAPerson(index, people); // 'people is a List of Type Person.

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            // Method overload & Optional parameter - Video 78.

            // Searching a List for custom object - Video 79.
            Console.WriteLine("Enter the firstname you want to find from the people list:");
            string UserSearchFirstnameInput = Console.ReadLine();
            Console.WriteLine(Person.FindPerson(people, UserSearchFirstnameInput));

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            // Override Equals methods - Video 82.
            bool TestEquals = people[0].Equals(people[1]);
            Console.WriteLine($"is {people[0]} and {people[1]} is the same object? the answer is {TestEquals}");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            // Method Overload - Video 83
            Person toComparePerson = new Person() { FirstName = "Dudley", SecondName = "Fearn", Age = "34" };
            people.Add(toComparePerson);
            Console.WriteLine(Person.FindPerson(people, toComparePerson));

            Console.WriteLine("\n><><><><><><> Do you want to search database with using Age ? y/n <><><><><><><\n");
            string UserSearchForAge = Console.ReadLine().ToLower();
            switch (UserSearchForAge)
            {
                case "y":
                    Console.WriteLine("What Age do you want to search?");
                    string UserSearchAgeInput = Console.ReadLine();
                    Person.FindAge(people, UserSearchAgeInput);

                    Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
                    Console.WriteLine("Grouped people by age coutesy of LINQ:");
                    var sameAgeQuery = from person in people
                                       group person by person.Age into ageGroup
                                       orderby ageGroup.Key
                                       select ageGroup;

                    foreach (var ageGroup in sameAgeQuery)
                    {
                        Console.WriteLine($"List of person Aged: {ageGroup.Key}");
                        foreach (Person person in ageGroup)
                        {
                            Console.WriteLine(person.Fullname + " with age of " + person.Age);
                        }
                    }

                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("No input or incorrect input is chosen - exiting search by Age.");
                    break;
            }

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            // How to return Custom object from Method - Video 85


            Console.ReadKey();
        }
    }
}
