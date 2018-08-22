using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Scale%20Balancing:Csharp
Using the C# language, have the function ScaleBalancing(strArr) read strArr which will contain two elements, the first being the two positive integer 
weights on a balance scale (left and right sides) and the second element being a list of available weights as positive integers. 
Your goal is to determine if you can balance the scale by using the least amount of weights from the list, but using at most only 2 weights. 

For example: if strArr is ["[5, 9]", "[1, 2, 6, 7]"] then this means there is a balance scale with a weight of 5 on the left side and 9 on the right side. 
It is in fact possible to balance this scale by adding a 6 to the left side from the list of weights and adding a 2 to the right side. 
Both scales will now equal 11 and they are perfectly balanced. Your program should return a comma separated string of the weights that were used 
from the list in ascending order, so for this example your program should return the string 2,6 

There will only ever be one unique solution and the list of available weights will not be empty. It is also possible to add two weights to only one 
side of the scale to balance it. If it is not possible to balance the scale then your program should return the string not possible. 

Sample Test Cases
Input:"[3, 4]", "[1, 2, 7, 7]"
Output:"1"

Input:"[13, 4]", "[1, 2, 3, 6, 14]"
Output:"3,6"
*/

namespace CoderByte013ScaleBalancing
{
    class Program
    {
        public static string ScaleBalancing(string[] strArray)
        {
            char[] numbers = "0123456789,".ToCharArray();
            string temp = string.Empty;

            temp = new string(strArray[0].Where(c => numbers.Any(n => n == c)).ToArray());
            int[] weights = temp.Split(',').Select(i => int.Parse(i)).ToArray();
            Array.Sort(weights);

            temp = new string(strArray[1].Where(c => numbers.Any(n => n == c)).ToArray());
            int[] options = temp.Split(',').Select(i => int.Parse(i)).ToArray();

            int difference = weights[1] - weights[0];

            if (options.Where(i => i == difference).Count() > 0)
            {
                return difference.ToString();
            }

            for (int i = 0; i < options.Length; i++)
                for (int j = 0; j < options.Length; j++)
                {
                    if (j == i) continue;
                    if ((options[i] + options[j] == difference) || (Math.Abs(options[i] - options[j]) == difference))
                        return String.Format("{0}, {1}", options[i], options[j]);
                }

            return "not possible";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ScaleBalancing(new[] { "[13, 4]", "[1, 2, 3, 6, 14]" }));
        }
    }
}
