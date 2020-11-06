// Edrick Tamayo
// Thursday 3:30PM
// November 6, 2020

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class MergeSort
    {
        // Sort method that takes in the array as an IComparable array to use 
        // CompareTo method, and the size of the array since original array may
        // have null values in it
        // Outside Reference: https://algs4.cs.princeton.edu/22mergesort/Merge.java.html
        public static void Sort(IComparable[] a, int size)
        {
            // New IComparable array set to original arrays size
            IComparable[] aux = new IComparable[size];
            // Call next method passing in the array, aux array, 0 as the low and
            // size - 1 as the high value
            Sort(a, aux, 0, size - 1);
        }

        // Will use recursion to sort through the array
        private static void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            // Base case
            if (hi <= lo) return;
            // Mid point of array
            int mid = lo + (hi - lo) / 2;
            // Recursion calls to sort and merge
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        // Will merge arrays once sorting is finished and Merge is reached in the
        // call stack
        private static void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            // Copy the array into temporary array
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;

            // Comparing the values of the array
            for (int k = lo; k <= hi; k++)
            {
                // If i is greater than the mid, put rest on right
                if (i > mid)
                    a[k] = aux[j++];
                // If j is greater than max of array, put to left
                else if (j > hi)
                    a[k] = aux[i++];
                // If value of j is less than value of i, put j into array
                else if (aux[j].CompareTo(aux[i]) < 0)
                    a[k] = aux[j++];
                // Else if the value of i is less than j, then put i into array
                else
                    a[k] = aux[i++];
            }
        }
    }
}
