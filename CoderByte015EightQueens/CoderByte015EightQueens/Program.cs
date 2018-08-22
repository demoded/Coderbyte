using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.coderbyte.com/editor/guest:Eight%20Queens:Csharp
Using the C# language, have the function EightQueens(strArr) read strArr which will be an array consisting of the locations of eight Queens on 
a standard 8x8 chess board with no other pieces on the board. The structure of strArr will be the following: ["(x,y)", "(x,y)", ...] 
where (x,y) represents the position of the current queen on the chessboard (x and y will both range from 1 to 8 where 1,1 is the bottom-left 
of the chessboard and 8,8 is the top-right). Your program should determine if all of the queens are placed in such a way where none of them 
are attacking each other. If this is true for the given input, return the string true otherwise return the first queen in the list that is attacking 
another piece in the same format it was provided. 

For example: if strArr is ["(2,1)", "(4,2)", "(6,3)", "(8,4)", "(3,5)", "(1,6)", "(7,7)", "(5,8)"] then your program should return the string true. 
The corresponding chessboard of queens for this input is below (taken from Wikipedia). 

https://i.imgur.com/zAT24ML.png
 
Sample Test Cases
Input:"(2,1)", "(4,3)", "(6,3)", "(8,4)", "(3,4)", "(1,6)", "(7,7)", "(5,8)"
Output:"(2,1)"

Input:"(2,1)", "(5,3)", "(6,3)", "(8,4)", "(3,4)", "(1,8)", "(7,7)", "(5,8)"
Output:"(5,3)"
*/

namespace CoderByte015EightQueens
{
    class Program
    {
        static int[,] chessField;

        public static int CheckPosition(int _x, int _y, int[] _pos)
        {
            if (_x >= 0 && _x < 8 &&
               _y >= 0 && _y < 8 &&
               !(_x == _pos[0] && _y == _pos[1])
                )
                return chessField[_x, _y];
            else
                return 0;
        }

        public static string ValidateChessboard(List<int[]> _positions)
        {

            foreach (var pos in _positions)
            {
                //Console.WriteLine(String.Format("({0},{1})", pos[0], pos[1]));
                for (int i = 0; i <= 7; i++)
                {
                    List<int> listY = new List<int>();

                    int x = pos[0] - (pos[0] - i);

                    listY.Add(pos[1]);                  //y position on the same row (horizontal)
                    listY.Add(pos[1] - (pos[0] - i));   //y position below horizontal
                    listY.Add(pos[1] + (pos[0] - i));   //y position above horizontal

                    foreach (int y in listY)
                    {
                        if (CheckPosition(x, y, pos) == 1)
                        {
                            return String.Format("({0},{1})", pos[0]+1, pos[1]+1);
                        }
                    }

                    //additionally check VERTICAL with the original X position and i as Y
                    if (CheckPosition(pos[0], i, pos) == 1)
                    {
                        return String.Format("({0},{1})", pos[0]+1, pos[1]+1);
                    }

                }
            }

            return "true";
        }

        public static string EightQueens(string[] strArr)
        {
            chessField = new int[8, 8];
            int[] positionXY = new int[2];
            List<int[]> positions = new List<int[]>();

            Array.Clear(chessField, 0, chessField.Length);

            foreach (string s in strArr)
            {
                string[] strPos = s.Substring(1, 3).Split(',');
                
                int.TryParse(strPos[0], out positionXY[0]);
                int.TryParse(strPos[1], out positionXY[1]);

                chessField[positionXY[0]-1, positionXY[1]-1] = 1;

                positions.Add(new[] { positionXY[0]-1, positionXY[1] -1});
            }

            for (int y = 7; y >= 0; y--)
            {
                Console.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", chessField[0, y], chessField[1, y], chessField[2, y], chessField[3, y], chessField[4, y], chessField[5, y], chessField[6, y], chessField[7, y]));
            }

            var r = positions.AsEnumerable().Reverse();
            return ValidateChessboard(positions);
        }

            static void Main(string[] args)
        {
            Console.WriteLine(EightQueens(new string[] { "(2,1)", "(5,3)", "(6,3)", "(8,4)", "(3,4)", "(1,8)", "(7,7)", "(5,8)" }));
            Console.WriteLine(EightQueens(new string[] { "(2,1)", "(4,3)", "(6,3)", "(8,4)", "(3,4)", "(1,6)", "(7,7)", "(5,8)" }));
        }
    }
}
