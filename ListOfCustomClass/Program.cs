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
            Console.WriteLine("Hello World! start of My Own Practice with Caleb Curry Video Tutorial helps :)");

            Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");
            
            /* creating a new list called 'people' */
            List<Person> people = new List<Person>();

            /* instance of Person > person1 object */
            //var person1 = new Person();
            //person1.FirstName = "Budong";
            //person1.SecondName = "Drummond";
            //Console.WriteLine($"Hi, {person1.FirstName}, Enter the year you are born in:");
            //int birthYear = Convert.ToInt32(Console.ReadLine());
            //person1.CalculateAge(birthYear);
            //Console.WriteLine($"So I know you are now {person1.Age} years old");

            //Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            /* another instance of Person > person2 object. Alternative simplified was to create and set names. */
            //var person2 = new Person { FirstName = "Clare", SecondName = "Carney" };
            //Console.WriteLine($"Hi, {person2.FirstName}, Enter the year you are born in:");
            //int birthYear2 = Convert.ToInt32(Console.ReadLine());
            //person2.CalculateAge(birthYear2);
            //Console.WriteLine($"So I know you are now {person2.Age} years old");

            //Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><\n");

            //people.Add(person1);
            //people.Add(person2);

            /* Adding or filling value as a custome type inside a loop. e.g., asking user in console to add value in the loop
             * you can create user as many as you want it, alternatively, reading from a file, 
             * putting everything in the object and add it to the list.
             */

            /* keep asking user until exit is chosen. */
            bool KeepGoing = true;
            do
            {
                // Using switch statement to add more user or not, via console.                
                Console.WriteLine("Enter your options: " +
                    "\nEnter 1 to insert a new object of Person Type." +
                    "\nEnter 2 to view the the People List<> of Person Type." +
                    "\nEnter 3 to search Person by index value" +
                    "\nEnter 4 to search Person by it first name" +
                    "\nEnter 5 to compare 2 objects of Person by it's indexes value" +
                    "\nEnter 6 to search or grouped Person by it's age" +
                    "\nEnter 0 to exit programme.");
                string userAddMoreUserInput = Console.ReadLine().ToLower();
                switch (userAddMoreUserInput)
                {
                    case "1":
                        Console.WriteLine("\n><><><><><><><><><><><> Option 1 selected <><><><><><><><><><><><\n");
                        
                        String[] FirstAndSecondName = new String[2];
                        
                        Console.WriteLine("Enter the fullname seperated by a space: ");

                        // read full name, convert all names to lower case
                        string UserFullName = Console.ReadLine().ToLower();

                        // set what is the seperators characters between 1st & 2nd name
                        /* String[] Seperator = { " ", ",", "" }; */
                        string separator = " ";

                        // split the UserFullName into 2 and store it in new string array. removed any empty spaces.
                        /* String[] FirstAndSecondName = UserFullName.Split(Seperator, 2, StringSplitOptions.RemoveEmptyEntries); */

                        // split the UserFullName into 2 using separator
                        string[] names = UserFullName.Split(separator); // using names array to avoid error here
                        // if there are more than 1 name entered assign to FirstAndSecondName, else if, only 1 name entered - insert empty space for 2nd name
                        if (names.Length > 1)
                        {
                            for (int i = 0; i < FirstAndSecondName.Length; i++)
                            {
                                FirstAndSecondName[i] = names[i];
                            }
                        }
                        // else if there is only one name entered than automatically assign to 1st name only & 2nd name as null
                        else if (names.Length == 1)
                        {
                            FirstAndSecondName[0] = names[0];
                            FirstAndSecondName[1] = null;
                        }
                        var NewPerson = new Person { FirstName = FirstAndSecondName[0], SecondName = FirstAndSecondName[1] }; // add 1st & 2nd name taken from String array

                        Console.WriteLine("Enter the year you are born in:");
                        int UserBirthYear = Convert.ToInt32(Console.ReadLine());

                        NewPerson.CalculateAge(UserBirthYear); // calculate age from given birth year.
                        people.Add(NewPerson); // add new person to people List
                        Console.WriteLine(">>> Successfully added this person to the people list <<<");
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("\n><><><><><><><><><><><> Option 2 selected <><><><><><><><><><><><\n");
                        
                        Console.WriteLine($"Currently, there are {people.Count} people in the list:");
                        
                        // Iterate the people List
                        foreach (Person person in people)
                        {
                            Console.WriteLine(" - " + person.ToString());
                        }
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("\n><><><><><><><><><><> Option 3 selected <><><><><><><><><><><><><\n");
                        
                        // Passing custom type into method - Video 73.
                        int PeopleListCount = people.Count();

                        int count = 0;
                        while (count < 1)
                        {
                            Console.WriteLine($"Insert the element value of the person you want to pick from people list between 1 to {Convert.ToString(PeopleListCount)}:");
                            int ReadIndexInput = Convert.ToInt32(Console.ReadLine());
                                if (ReadIndexInput > PeopleListCount)
                                {
                                    throw new ArgumentOutOfRangeException("The element value you've entered is invalid");
                                }
                                if (ReadIndexInput > 0 && ReadIndexInput <= PeopleListCount)
                                {
                                    count += 1;
                                    int index = ReadIndexInput - 1;
                                    Person.PickAPerson(people[index]);

                                    // Static Method using overload (Method to Take an ArrayList of Custom Type) - Video 76.
                                    Person.PickAPerson(index, people); // 'people is a List of Type Person.
                                }
                        }
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("\n><><><><><><><><><><> Option 4 selected <><><><><><><><><><><><><\n");

                        // Searching a List for custom object - Video 79.
                        Console.WriteLine("Enter the firstname you want to find from the people list:");
                        string UserSearchFirstnameInput = Console.ReadLine().ToLower(); // add to lower here
                        Console.WriteLine(Person.FindPerson(people, UserSearchFirstnameInput));
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        Console.WriteLine("\n><><><><><><><><><><> Option 5 selected <><><><><><><><><><><><><\n");
                        /* prompt user to compare 2 objects using index element. will never return true as technically 2 objects are different entities */
                        // Override Equals methods - Video 82.
                        bool TestEquals = people[0].Equals(people[1]);
                        Console.WriteLine($"is {people[0]} and {people[1]} is the same object? the answer is {TestEquals}");

                        /* prompt user to compare 2 objects using Equals override method using firstname properties. so it return as true */
                        // Method Overload - Video 83
                        Person toComparePerson = new Person() { FirstName = "Dudley", SecondName = "Fearn", Age = "34" };
                        people.Add(toComparePerson);
                        Console.WriteLine(Person.FindPerson(people, toComparePerson));
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        Console.WriteLine("\n><><><><><><><><><><> Option 6 selected <><><><><><><><><><><><><\n");

                        bool Option6 = true;
                        do
                        {
                            // Method overload & Optional parameter - Video 78.
                            Console.WriteLine("Follow the instruction below..." +
                                "\nEnter s to SEARCH and list Person(s) by its age" +
                                "\nEnter g to GROUPED and display Person(s) by its age" +
                                "\nEnter 0 to to Exit");

                            string UserOption6_Input = Console.ReadLine().ToLower();
                            switch (UserOption6_Input)
                            {
                                case "s":
                                    Console.WriteLine("What is the age do you want to search?");
                                    string UserSearchAgeInput = Console.ReadLine();
                                    Person.FindAge(people, UserSearchAgeInput);
                                    break;

                                case "g":
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
                                case "0":
                                    Console.WriteLine("No longer searching by Age");
                                    Option6 = false;
                                    break;
                                default:
                                    Console.WriteLine("No input or incorrect input is chosen - exiting search by Age.");
                                    break;
                            }
                        } while (Option6);
                        Console.WriteLine("Hit any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.WriteLine("\n><><><><><><><><><><> Option 0 selected <><><><><><><><><><><><><\n");
                        Console.WriteLine("Exiting Programme\n");
                        KeepGoing = false;
                        break;
                    default:
                        break;
                }
            } while (KeepGoing);

            /* An example of one liner for the same result on creating list and assign person1 & person2:
             * List<Person> people = new List<Person>(){person1, person2};*/

            /* >>>>> List<Person> people = new List<Person>(); <<<<<
               is the list we are working on in this Main method.*/

            // How to return Custom object from Method - Video 85

            Console.ReadKey();
        }
    }
}
