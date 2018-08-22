using System;
/*
https://www.coderbyte.com/editor/guest:Letter%20Capitalize:Csharp
Using the C# language, have the function  LetterCapitalize(str) take the str parameter being passed and capitalize the first letter of each word. 
Words will be separated by only one space. 

Sample Test Cases
Input:"hello world"
Output:"Hello World"

Input:"i ran there"
Output:"I Ran There"
*/

class MainClass
{
    public static string LetterCapitalize(string str)
    {

        string res = "";

        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (i > 0 && str[i-1] == ' ')
                res += Char.ToUpper(c);
            else
                res += Char.ToUpper(c);
        }

        return res;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(LetterCapitalize(Console.ReadLine()));
    }

}
