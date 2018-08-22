using System;
/*
https://www.coderbyte.com/editor/guest:Alphabet%20Soup:Csharp
Using the C# language, have the function  AlphabetSoup(str) take the str string parameter being passed and return the string with the letters 
in alphabetical order (ie. hello becomes ehllo). Assume numbers and punctuation symbols will not be included in the string. 

Sample Test Cases
Input:"coderbyte"
Output:"bcdeeorty"

Input:"hooplah"
Output:"ahhloop"
*/
class MainClass
{
    public static string AlphabetSoup(string str)
    {
        char[] ca = str.ToCharArray();

        Array.Sort(ca);

        return new string(ca);

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(AlphabetSoup(Console.ReadLine()));
    }
}
