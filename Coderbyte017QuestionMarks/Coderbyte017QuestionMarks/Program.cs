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

Input:"acc?7??sss?3rr1??????5" <--- THAT IS POSSIBLY WRONG!!! IT MUST BE FALSE ACCORDING TO TASK
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
            int left=0, right = 0;

            for (int i = 1; i < filtered.Length; i++)
            {
                if (i < filtered.Length - 3)
                {
                    //check all possible combinations for Number???Number
                    if (Char.IsNumber(filtered[i - 1]) &&
                       filtered[i] == '?' && filtered[i + 1] == '?' && filtered[i + 2] == '?' &&
                       Char.IsNumber(filtered[i + 3]))
                    {
                        left = Convert.ToInt16(filtered[i - 1]) - '0';
                        right = Convert.ToInt16(filtered[i + 3]) - '0';

                        if (left + right == 10)
                        {
                            ret = true;
                        }

                        i += 3; //add 3 here, another 1 will be added in for loop
                    }
                    else
                    {
                        //if current and previous characters not numbers, there is no reason to continue, return false
                        if (!(Char.IsNumber(filtered[i - 1]) && Char.IsNumber(filtered[i])))
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                else
                {
                    //check the last 4 symbols if they shouldn't contain questionmarks
                    if (ret && filtered[i] == '?')
                        ret = false;
                }
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
