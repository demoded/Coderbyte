using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Correct%20Path:Csharp
Using the C# language, have the function  CorrectPath(str) read the str parameter being passed, which will represent the movements made 
in a 5x5 grid of cells starting from the top left position. The characters in the input string will be entirely composed of: r, l, u, d, ?. 
Each of the characters stand for the direction to take within the grid, for example: r = right, l = left, u = up, d = down. 
Your goal is to determine what characters the question marks should be in order for a path to be created to go from the top left of the grid 
all the way to the bottom right without touching previously travelled on cells in the grid. 

For example: if str is "r?d?drdd" then your program should output the final correct string that will allow a path to be formed from the 
top left of a 5x5 grid to the bottom right. For this input, your program should therefore return the string rrdrdrdd. There will only ever be 
one correct path and there will always be at least one question mark within the input string. 

Sample Test Cases
Input:"???rrurdr?"
Output:"dddrrurdrd"

Input:"drdr??rrddd?"
Output:"drdruurrdddd"
*/

namespace CoderByte012CorrectPath
{
    class Program
    {
        public static bool validPath(string str)
        {
            int x = 0;
            int y = 0;
            char[,] field = new char[5,5];

            for (int i = 0; i < str.Length; i++)
            {
                if (field[x, y] == '1')
                    return false;
                else
                    field[x, y] = '1';

                if (str[i] == 'r')
                    x++;
                else if (str[i] == 'l')
                    x--;
                else if (str[i] == 'u')
                    y--;
                else if (str[i] == 'd')
                    y++;

                if (x > 4 || y > 4 || x < 0 || y < 0) return false;
            }

            if (x == 4 && y == 4)
                return true;

            return false;
        }

        public static string nextMask(string mask)
        {
            char[] newMask = mask.ToCharArray();
            bool carryFlag = false;

            //for the first run update ? in mask to U
            if (mask.IndexOf("?") > -1)
            {
                newMask = mask.Replace('?', 'd').ToCharArray();
            }
            else
                for (int i = newMask.Length - 1; i >= 0; i--)
                {
                    if (i == newMask.Length - 1)
                        carryFlag = true;

                    if (carryFlag)
                    {
                        carryFlag = false;
                        if (newMask[i] == 'l')
                        {
                            newMask[i] = 'd';
                            carryFlag = true;
                        }
                        else if (newMask[i] == 'd')
                            newMask[i] = 'u';
                        else if (newMask[i] == 'u')
                            newMask[i] = 'r';
                        else if (newMask[i] == 'r')
                            newMask[i] = 'l';
                    }
                }

            return new string(newMask);
        }

        public static string updateMove(string str, string mask)
        {
            int maskIndex = 0;
            string ret = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                    ret += mask[maskIndex++];
                else
                    ret += str[i];
            }

            return ret;
        }

        public static string CorrectPath(string str)
        {
            string ret = "";
            string mask = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                    mask += '?';
            }

            while (!validPath(ret))
            {
                mask = nextMask(mask);
                ret = updateMove(str, mask);
            }
            return ret;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CorrectPath(Console.ReadLine()));
        }
    }
}
