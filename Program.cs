using System;
using System.Linq;

namespace FindPythagoreanTriplet
{
    class Program
    {
        // A C# program that returns true  
        // if there is a Pythagorean 
        // Triplet in a given aray. 

        static void Main(string[] args)
        {
            int[] array = { 3, 1, 4, 6, 0, 5, 0, 0, 13, 15, 12 }; // several triplets
            //int[] array = { 3, 1, 4, 6}; // no triplet

            Console.WriteLine("Original array");
            printArray(array);
            Console.WriteLine();

            bool tripletFound = isTripletBruteForce(array);
            Console.WriteLine("Triplet {0}found", tripletFound ? "" : "not " );

            tripletFound = findATripletWithSort(array);
            Console.WriteLine("Triplet {0}found with sort", tripletFound ? "" : "not ");

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        // Returns true if there is Pythagorean 
        // triplet in array[0..n-1] 
        static bool isTripletBruteForce(int[] a)
        {
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {

                        // Calculate square of array elements 
                        int x = a[i] * a[i], y =
                                a[j] * a[j], z =
                                a[k] * a[k];

                        if (x == y + z ||
                            y == x + z ||
                            z == x + y)
                            return true;
                    }
                }
            }

            // If we reach here,  
            // no triplet found 
            return false;
        }

        static bool findATripletWithSort(int[] a)
        {
            bool isFound = false;
            Array.Sort(a);
            int n = a.Length;

            // Square array elements 
            for (int i = 0; i < n; i++)
                a[i] = a[i] * a[i];

            // Now fix one element one by one  
            // and find the other two elements 
            for (int i = n - 1; i >= 2; i--)
            {
                // To find the other two elements,  
                // start two index variables from  
                // two corners of the array and  
                // move them toward each other 
                // index of the first element  
                // in arr[0..i-1] 
                int l = 0;  // left index

                // index of the last element  
                // in arr[0..i - 1] 
                int r = i - 1;  // right index
                while (l < r)
                {

                    // A triplet found 
                    if (a[l] + a[r] == a[i]) {
                        //return true;
                        isFound = true;
                        Console.WriteLine("{0} + {1} = {2}", a[l],a[r],a[i]);
                    }

                    // Else either move 'l' or 'r' 
                    if (a[l] + a[r] < a[i])
                        l++;
                    else
                        r--;
                }
            }

            return isFound;
        }


        static void printArray(int[] a) {
            a.ToList().ForEach(e => { Console.Write(e + " "); });
        }
    }
}
