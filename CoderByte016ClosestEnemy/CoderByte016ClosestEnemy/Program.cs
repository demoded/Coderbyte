using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Closest%20Enemy%20II:Csharp
Using the C# language, have the function ClosestEnemyII(strArr) read the matrix of numbers stored in strArr which will be a 2D matrix that contains only the integers 1, 0, or 2. 
Then from the position in the matrix where a 1 is, return the number of spaces either left, right, down, or up you must move to reach an enemy which is represented by a 2. 
You are able to wrap around one side of the matrix to the other as well. For example: if strArr is ["0000", "1000", "0002", "0002"] then this looks like the following: 

0 0 0 0
1 0 0 0
0 0 0 2
0 0 0 2 

For this input your program should return 2 because the closest enemy (2) is 2 spaces away from the 1 by moving left to wrap to the other side and then moving down once. 
The array will contain any number of 0's and 2's, but only a single 1. It may not contain any 2's at all as well, where in that case your program should return a 0. 

    Sample Test Cases
    Input:"000", "100", "200"
    Output:1

    Input:"0000", "2010", "0000", "2002"
    Output:2 
*/

namespace CoderByte016ClosestEnemy
{
    class Program
    {
        public static string ClosestEnemyII(string[] strArr)
        {
            int ret = Int32.MaxValue;
            int steps = 0;
            int sizeY = strArr.Length;
            int sizeX = strArr[0].Length;
            int playerX = 0, playerY = 0;


            // martix declared as 3x3 of original strArr
            int[,] matrix = new int[sizeX*3, sizeY*3];

            for (int i = 0; i < sizeY; i++)
            {
                string row = strArr[i];
                for (int j = 0; j < sizeX; j++)
                {
                    int n = Convert.ToInt32(row[j])-48;
                    int o = (n == 1) ? 0 : n; //all values except 1

                    if (n == 1)
                    {
                        playerX = sizeX + j;
                        playerY = sizeY + i;
                    }

                    //original matrix will be added 9 times to not care about mirroring and find solution in one run
                    //also only center replica has 1 in it to keep player position unique
                    matrix[j, i] = o;           matrix[j + sizeX, i] = o;           matrix[j + sizeX * 2, i] = o;
                    matrix[j, i + sizeY] = o;   matrix[j + sizeX, i + sizeY] = n;   matrix[j + sizeX * 2, i + sizeY] = o;
                    matrix[j, i + sizeY*2] = o; matrix[j + sizeX, i + sizeY*2] = o; matrix[j + sizeX * 2, i + sizeY*2] = o;
                }
            }

            for (int i = 0; i < sizeY * 3; i++)
            {
                for (int j = 0; j < sizeX * 3; j++)
                {
                    if (matrix[j, i] == 2)
                    {
                        steps = Math.Abs(j - playerX) + Math.Abs(i-playerY);

                        if (steps < ret)
                            ret = steps;
                    }
                }
            }

            if (ret == Int32.MaxValue)
                return "0";
            else
                return ret.ToString();
        }

            static void Main(string[] args)
        {
            Console.WriteLine(ClosestEnemyII(new string[] { "000", "100", "200" }));
        }
    }
}
