using System;
/*
https://www.coderbyte.com/editor/guest:Time%20Convert:Csharp
Using the C# language, have the function  TimeConvert(num) take the num parameter being passed and return the number of hours and minutes 
the parameter converts to (ie. if num = 63 then the output should be 1:3). Separate the number of hours and minutes with a colon. 

Sample Test Cases
Input:126
Output:"2:6"

Input:45
Output:"0:45"
*/
class MainClass
{
    public static string TimeConvert(int num)
    {

        string res = "";

        res += ((int)(num / 60)).ToString() + ':' + ((num % 60)*60).ToString();

        return res;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(TimeConvert(Convert.ToInt16( Console.ReadLine())));
    }

}