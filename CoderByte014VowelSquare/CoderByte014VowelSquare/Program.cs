using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Vowel%20Square:Csharp
Using the C# language, have the function VowelSquare(strArr) take the strArr parameter being passed which will be a 2D matrix of some arbitrary 
size filled with letters from the alphabet, and determine if a 2x2 square composed entirely of vowels exists in the matrix. 
For example: strArr is ["abcd", "eikr", "oufj"] then this matrix looks like the following: 

a b c d
e i k r
o u f j 

Within this matrix there is a 2x2 square of vowels starting in the second row and first column, namely, ei, ou. If a 2x2 square of vowels is found 
your program should return the top-left position (row-column) of the square, so for this example your program should return 1-0. 
If no 2x2 square of vowels exists, then return the string not found. If there are multiple squares of vowels, return the one that is 
at the most top-left position in the whole matrix. The input matrix will at least be of size 2x2. 

Sample Test Cases
Input:"aqrst", "ukaei", "ffooo"
Output:"1-2"

Input:"gg", "ff"
Output:"not found"
*/

namespace CoderByte014VowelSquare
{
    class Program
    {
        public static string VowelSquare(string[] strArr)
        {
            int ySize = strArr.Length;
            int xSize = strArr[0].Length;
            string vowels = "aeiou";

            int[,] matrix = new int[xSize, ySize];
            for (int i = 0; i < ySize; i++)
                for (int j = 0; j < xSize; j++)
                    if (vowels.IndexOf(strArr[i][j]) >= 0)
                        matrix[j, i] = 1;
                    else
                        matrix[j, i] = 0;

            for (int i = 0; i < ySize-1; i++)
                for (int j = 0; j < xSize-1; j++)
                {
                    if ((matrix[j, i] + matrix[j + 1, i] + matrix[j, i + 1] + matrix[j + 1, i + 1]) == 4)
                        return String.Format("{0}-{1}", i, j);
                }

            return "not found";
        }

            static void Main(string[] args)
        {
            Console.WriteLine(VowelSquare(new[] { "aqrst", "ukaei", "ffooo" }));
        }
    }
}
