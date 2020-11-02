using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private IDroid[] droidCollection;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;

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

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                ProtocolDroid protocolDroid = new ProtocolDroid(Material, Color, NumberOfLanguages);
                droidList.Push(protocolDroid);
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
                droidList.Push(utilityDroid);
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
                droidList.Push(janitorDroid);
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
                droidList.Push(astromechDroid);
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
        public static void PopulateList()
        {
            if (addOnceBool == false)
            {
                ProtocolDroid protocolDroid = new ProtocolDroid("Quadranium", "White", 1);
                droidList.Push(protocolDroid);
                AstromechDroid astromechDroid = new AstromechDroid("Carbonite", "White", true, true, true, true, 1);
                droidList.Push(astromechDroid);
                UtilityDroid utilityDroid = new UtilityDroid("Carbonite", "White", true, true, true);
                droidList.Push(utilityDroid);
                JanitorDroid janitorDroid = new JanitorDroid("Carbonite", "White", true, true, true, true, true);
                droidList.Push(janitorDroid);
                JanitorDroid janitor2Droid = new JanitorDroid("Quadranium", "Red", false, false, false, false, false);
                droidList.Push(janitorDroid);
                ProtocolDroid protocol2Droid = new ProtocolDroid("Carbonite", "Red", 2);
                droidList.Push(protocolDroid);
                UtilityDroid utility2Droid = new UtilityDroid("Quadranium", "Red", false, false, false);
                droidList.Push(utilityDroid);
                AstromechDroid astromech2Droid = new AstromechDroid("Quadranium", "Red", false, false, false, false, 2);
                droidList.Push(astromechDroid);

                addOnceBool = true;
            }
            else
            {
                Console.WriteLine("List already populated" + Environment.NewLine);
            }
        }
        // Outside reference: https://stackoverflow.com/questions/19396346/how-to-iterate-through-linked-list/19396384
        public void SortByModel()
        {
            IDroid droid;
            for (int i = 0; droidList.GetList(i) != null; i++)
            {
                if (droidList.GetList(i) is ProtocolDroid)
                {
                    droid = droidList.GetList(i);
                    protocolStack.Push((ProtocolDroid)droid);
                }
                if (droidList.GetList(i) is UtilityDroid)
                {
                    droid = droidList.GetList(i);
                    utilityStack.Push((UtilityDroid)droid);
                }
                if (droidList.GetList(i) is JanitorDroid)
                {
                    droid = droidList.GetList(i);
                    janitorStack.Push((JanitorDroid)droid);
                }
                if (droidList.GetList(i) is AstromechDroid)
                {
                    droid = droidList.GetList(i);
                    astromechStack.Push((AstromechDroid)droid);
                }
            }
        }
    }
}
