using System;
/*
https://www.coderbyte.com/editor/guest:Simple%20Symbols:Csharp
Using the C# language, have the function  SimpleSymbols(str) take the str parameter being passed and determine if it is an acceptable sequence 
by either returning the string true or false. The str parameter will be composed of + and = symbols with several letters between them (ie. ++d+===+c++==a) 
and for the string to be true each letter must be surrounded by a + symbol. So the string to the left would be false. 
The string will not be empty and will have at least one letter. 

Sample Test Cases
Input:"+d+=3=+s+"
Output:"true"

Input:"f++d+"
Output:"false"
*/
class MainClass
{
    public static string SimpleSymbols(string str)
    {
        if (char.IsLetter(str[0]))
            return "false";

        if (Char.IsLetter(str[str.Length-1]))
            return "false";

        for (int i = 1; i < str.Length - 1; i++)
        {
            if (char.IsLetter(str[i]) && (str[i - 1] != '+' || str[i + 1] != '+'))
                return "false";
        }

        return "true";
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(SimpleSymbols(Console.ReadLine()));
    }

}