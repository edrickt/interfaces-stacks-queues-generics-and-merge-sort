// Edrick Tamayo
// Thursday 3:30PM
// November 6, 2020

using System;
using System.Security.Cryptography.X509Certificates;

namespace cis237_assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            // Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            // Display the main greeting for the program
            userInterface.DisplayGreeting();

            // Display the main menu for the program
            userInterface.DisplayMainMenu();

            // Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            // While the choice is not equal to 3, continue to do work with the program
            while (choice != 9)
            {
                // Test which choice was made
                switch (choice)
                {
                    // Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;
                    // Choose to Print the droid
                    case 2:
                        DroidCollection.droidList.Display();
                        break;
                    // Sort by model
                    case 3:
                        userInterface.SortByModel();
                        break;
                    // Sort by price
                    case 4:
                        userInterface.SortByPrice();
                        break;
                    // Populate list
                    case 5:
                        userInterface.PopulateList();
                        break;
                }
                // Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }
        }
    }
}
