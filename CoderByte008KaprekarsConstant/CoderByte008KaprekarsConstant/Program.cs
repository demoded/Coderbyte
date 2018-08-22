using System;
/*
https://www.coderbyte.com/editor/guest:Kaprekars%20Constant:Csharp
Using the C# language, have the function KaprekarsConstant(num) take the num parameter being passed which will be a 4-digit number with 
at least two distinct digits. Your program should perform the following routine on the number: Arrange the digits in descending order and 
in ascending order (adding zeroes to fit it to a 4-digit number), and subtract the smaller number from the bigger number. 
Then repeat the previous step. Performing this routine will always cause you to reach a fixed number: 6174. 
Then performing the routine on 6174 will always give you 6174 (7641 - 1467 = 6174). Your program should return the number of times this routine 
must be performed until 6174 is reached. 
For example: if num is 3524 your program should return 3 because of the following steps: 
(1) 5432 - 2345 = 3087, (2) 8730 - 0378 = 8352, (3) 8532 - 2358 = 6174. 

Hard challenges are worth 15 points and you are not timed for them. 
 
Sample Test Cases
Input:2111
Output:5

Input:9831
Output:7
*/
class MainClass
{
    public static int KaprekarsConstant(int num)
    {
        int counter = 0;

        int first, second;
        char[] chars;

        while (num != 6174)
        {
            chars = num.ToString("D4").ToCharArray();

            Array.Sort(chars);
            second = Convert.ToInt16(new string(chars));

            Array.Reverse(chars);
            first = Convert.ToInt16(new string(chars));

            if (first > second) num = first - second;
            else if (second > first) num = second - first;
            else return 0;

            counter++;
        }
        return counter;

    }

    static void Main()
    {
        Console.WriteLine(KaprekarsConstant(Convert.ToInt16(Console.ReadLine())));
    }

}