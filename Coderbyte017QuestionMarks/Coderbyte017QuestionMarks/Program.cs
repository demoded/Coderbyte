using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*
https://www.coderbyte.com/editor/guest:Questions%20Marks:Csharp
Using the C# language, have the function QuestionsMarks(str) take the str string parameter, which will contain single digit numbers, letters, and question marks, 
and check if there are exactly 3 question marks between every pair of two numbers that add up to 10. If so, then your program should return the string true, 
otherwise it should return the string false. If there aren't any two numbers that add up to 10 in the string, then your program should return false as well. 

For example: if str is "arrb6???4xxbl5???eee5" then your program should return true because there are exactly 3 question marks between 6 and 4, 
and 3 question marks between 5 and 5 at the end of the string. 

Sample Test Cases
Input:"aa6?9"
Output:"false"

Input:"acc?7??sss?3rr1??????5"
Output:"true"
*/

namespace Coderbyte017QuestionMarks
{
    class Program
    {
        public static string QuestionsMarks(string str)
        {
            string filtered = Regex.Replace(str, "([^0-9?])", "");
            bool ret = false;
            int left, right, startPos = 0;

            startPos = filtered.IndexOf("???");
            while (!ret && startPos > 0 && startPos <= filtered.Length - 3)
            {
                if (Char.IsNumber(filtered[startPos - 1]))
                {
                    left = Convert.ToInt16(filtered[startPos - 1]) - '0';
                }
                else
                {
                    left = 0;
                }

                if (Char.IsNumber(filtered[startPos + 3]))
                {
                    right = Convert.ToInt16(filtered[startPos + 3]) - '0';
                }
                else
                {
                    right = 0;
                }

                if (left + right == 10)
                    ret = true;
                else
                    startPos = filtered.IndexOf("???", startPos + 1);
            }

            return ret.ToString().ToLower();

        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(QuestionsMarks(Console.ReadLine()));
        }
    }
}
