using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        private static bool addOnceBool = false;

        public static GenericStack<ProtocolDroid> protocolStack = new GenericStack<ProtocolDroid>();
        public static GenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
        public static GenericStack<AstromechDroid> astromechStack = new GenericStack<AstromechDroid>();
        public static GenericStack<JanitorDroid> janitorStack = new GenericStack<JanitorDroid>();

        public static GenericStack<IDroid> droidList = new GenericStack<IDroid>();

        public static GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

        // Private variable to hold the collection of droids
        public static IDroid[] droidCollection;

        // Private variable to hold the length of the Collection
        public static int lengthOfCollection;

        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            // Set length of collection to 0
            lengthOfCollection = 0;
        }

        public DroidCollection()
        { }

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                ProtocolDroid protocolDroid = new ProtocolDroid(Material, Color, NumberOfLanguages);
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                droidList.Push(protocolDroid);
                lengthOfCollection++;
                // Return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                UtilityDroid utilityDroid = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                droidList.Push(utilityDroid);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                JanitorDroid janitorDroid = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                droidList.Push(janitorDroid);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                AstromechDroid astromechDroid = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                droidList.Push(astromechDroid);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }
            // Return the completed string
            return returnString;
        }
        public void PopulateList()
        {
            if (addOnceBool == false)
            {
                Add("Quadranium", "White", 1);
                Add("Carbonite", "White", true, true, true, true, 1);
                Add("Carbonite", "White", true, true, true);
                Add("Carbonite", "White", true, true, true, true, true);
                Add("Quadranium", "Red", false, false, false, false, false);
                Add("Tears of a Jedi", "Red", 2);
                Add("Quadranium", "Red", false, false, false);
                Add("Quadranium", "Red", false, false, false, false, 2);

                addOnceBool = true;
            }
            else
            {
                Console.WriteLine("LIST ALREADY POPULATED" + Environment.NewLine);
            }
        }
        // Outside reference: https://stackoverflow.com/questions/19396346/how-to-iterate-through-linked-list/19396384
        public static void SortByModel()
        {
            IDroid droid;

            while (droidList.IsEmpty != true)
            {
                droid = droidList.Pop();
                if (droid is ProtocolDroid)
                {
                    protocolStack.Push((ProtocolDroid)droid);
                }
                else if (droid is JanitorDroid)
                {
                    janitorStack.Push((JanitorDroid)droid);
                }
                else if (droid is AstromechDroid)
                {
                    astromechStack.Push((AstromechDroid)droid);
                }
                else if (droid is UtilityDroid)
                {
                    utilityStack.Push((UtilityDroid)droid);
                }
            }
            while (protocolStack.IsEmpty != true)
            {
                droidQueue.Enqueue(protocolStack.Pop());
            }
            while (utilityStack.IsEmpty != true)
            {
                droidQueue.Enqueue(utilityStack.Pop());
            }
            while (janitorStack.IsEmpty != true)
            {
                droidQueue.Enqueue(janitorStack.Pop());
            }
            while (astromechStack.IsEmpty != true)
            {
                droidQueue.Enqueue(astromechStack.Pop());
            }
            while (droidQueue.IsEmpty != true)
            {
                droid = droidQueue.Dequeue();
                droidList.Push(droid);
            }
        }
        public void SortByPrice()
        {
            foreach (IDroid droids in droidCollection)
            {
                if (droids != null)
                {
                    droids.CalculateTotalCost();
                }
            }

            MergeSort.Sort(droidCollection, lengthOfCollection);
        }
    }
}
