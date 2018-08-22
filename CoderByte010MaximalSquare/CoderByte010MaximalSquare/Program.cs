using System;
using System.Text.RegularExpressions;

/*
https://www.coderbyte.com/editor/guest:Maximal%20Square:Csharp
Using the C# language, have the function MaximalSquare(strArr) take the strArr parameter being passed which will be a 2D matrix of 0 and 1's, 
and determine the area of the largest square submatrix that contains all 1's. A square submatrix is one of equal width and height, 
and your program should return the area of the largest submatrix that contains only 1's. 
For example: if strArr is ["10100", "10111", "11111", "10010"] then this looks like the following matrix: 

1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0 

For the input above, you can see the bolded 1's create the largest square submatrix of size 2x2, so your program should return the area which is 4. 
You can assume the input will not be empty. 

Hard challenges are worth 15 points and you are not timed for them. 
 
Sample Test Cases
Input:"0111", "1111", "1111", "1111"
Output:9

Input:"0111", "1101", "0111"
Output:1
*/

class MainClass
{
    public static Boolean validateSquare(int[,] _matrix, int _x, int _y, int squareSize)
    {
        for (int y = _y; y < squareSize + _y; y++)
            for (int x = _x; x < squareSize + _x; x++)
            {
                if (_matrix[x, y] == 0)
                    return false;
            }

        return true;
    }

    public static int findMaxSquare(int[,] _matrix, int _matrixSizeX, int _matrixSizeY, int squareSize = 0)
    {
        Boolean squareFound = false;
        int searchRangeX = _matrixSizeX - squareSize;
        int searchRangeY = _matrixSizeY - squareSize;

        for (int y = 0; y <= searchRangeY; y++)
        {
            for (int x = 0; x <= searchRangeX; x++)
            {
                if (validateSquare(_matrix, x, y, squareSize))
                {
                    squareFound = true;
                    break;
                }
            }

            if (squareFound)
                break;
        }

        if (squareSize > 0 && !squareFound)
        {
            return findMaxSquare(_matrix, _matrixSizeX, _matrixSizeY, squareSize - 1);
        }
        else
            return squareSize;
    }

    public static string MaximalSquare(string _str)
    {
        string[] strArr = _str.Split(',');
        int matrixSizeY = strArr.Length;
        int matrixSizeX = Regex.Replace(strArr[0], "[^0-9]", "").Length;
        int[,] matrix = new int[matrixSizeX, matrixSizeY];

        for (int i=0; i < matrixSizeY; i++)
        {
            string line = Regex.Replace(strArr[i], "[^0-9]", "");
            for (int j = 0; j < line.Length; j++)
            {
                matrix[j, i] = Convert.ToInt16(line[j].ToString());
            }
        }

        return findMaxSquare(matrix, matrixSizeX, matrixSizeY, Math.Min(matrixSizeX, matrixSizeY)).ToString();

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(MaximalSquare(Console.ReadLine()));
    }

}