using System;

/*
https://www.coderbyte.com/editor/guest:Simple%20Adding:Csharp
Using the C# language, have the function  SimpleAdding(num) add up all the numbers from 1 to num. For example: if the input is 4 then your 
program should return 10 because 1 + 2 + 3 + 4 = 10. For the test cases, the parameter num will be any number from 1 to 1000. 

Sample Test Cases
Input:12
Output:78

Input:140
Output:9870
*/

class MainClass
{
    public static int SimpleAdding(int num)
    {
        for (int i = num - 1; i >= 1; i--) num += i;
        return num;
    }

    static void Main()
    {
        Console.WriteLine(SimpleAdding(Convert.ToInt16(Console.ReadLine())));
    }
}