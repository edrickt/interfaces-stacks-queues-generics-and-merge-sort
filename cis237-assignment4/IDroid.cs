﻿// Edrick Tamayo
// Thursday 3:30PM
// November 6, 2020

using System;

namespace cis237_assignment4
{
    interface IDroid : IComparable
    {
        // Method to calculate the total cost of a droid
        void CalculateTotalCost();

        // Property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
