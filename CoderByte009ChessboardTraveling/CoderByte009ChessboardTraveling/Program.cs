using System;

/*
https://www.coderbyte.com/editor/guest:Chessboard%20Traveling:Csharp
Using the C# language, have the function  ChessboardTraveling(str) read str which will be a string consisting of the location of a space on 
a standard 8x8 chess board with no pieces on the board along with another space on the chess board. 
The structure of str will be the following: "(x y)(a b)" where (x y) represents the position you are currently on with x and y 
ranging from 1 to 8 and (a b) represents some other space on the chess board with a and b also ranging from 1 to 8 where a > x and b > y. 
Your program should determine how many ways there are of traveling from (x y) on the board to (a b) moving only up and to the right. 
For example: if str is (1 1)(2 2) then your program should output 2 because there are only two possible ways to travel from space (1 1) 
on a chessboard to space (2 2) while making only moves up and to the right. 

Hard challenges are worth 15 points and you are not timed for them. 
 
Sample Test Cases
Input:"(1 1)(3 3)"
Output:6

Input:"(2 2)(4 3)"
Output:3
*/
class MainClass
{
    public static string ChessboardTraveling(string str)
    {
        int x = Convert.ToInt16(str[1]);
        int y = Convert.ToInt16(str[3]);
        int a = Convert.ToInt16(str[6]);
        int b = Convert.ToInt16(str[8]);
        int pathLength = (a - x) + (b - y);
        int topMoves = (b - y);

        int numerator = 1;
        for (int i = 0; i < topMoves; i++)
        {
            numerator = numerator * (pathLength - i);
        }

        int denumerator = factorial(topMoves);

        var res = (numerator / denumerator).ToString();
        return res;
    }

    public static int factorial(int num)
    {
        if (num > 1)
        {
            return num * factorial(num - 1);
        }
        return 1;
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(ChessboardTraveling(Console.ReadLine()));
    }

}