using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Pentagonal%20Number:Csharp
Using the C# language, have the function PentagonalNumber(num) read num which will be a positive integer and determine how many dots exist in 
a pentagonal shape around a center dot on the Nth iteration. For example, in the image below you can see that on the first iteration there is only 
a single dot, on the second iteration there are 6 dots, on the third there are 16 dots, and on the fourth there are 31 dots. 

https://i.imgur.com/fYj3yvL.png 

Your program should return the number of dots that exist in the whole pentagon on the Nth iteration. 

Hard challenges are worth 15 points and you are not timed for them. 
 
Sample Test Cases
Input:2
Output:6

Input:5
Output:51
*/

namespace CoderByte011PentagonalNumber
{
    class Program
    {
        public static int PentagonalNumber(int num)
        {
            if (num > 1)
                num = num + 3 * (num - 1) + (num - 2) + PentagonalNumber(num - 1);

            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PentagonalNumber(Convert.ToInt16(Console.ReadLine())));
        }
    }
}
