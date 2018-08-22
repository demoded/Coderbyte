using System;
/*
https://www.coderbyte.com/editor/guest:Letter%20Changes:Csharp
Using the C# language, have the function  LetterChanges(str) take the str parameter being passed and modify it using the following algorithm. 
Replace every letter in the string with the letter following it in the alphabet (ie. c becomes d, z becomes a). 
Then capitalize every vowel in this new string (a, e, i, o, u) and finally return this modified string. 
 
Sample Test Cases
Input:"hello*3"
Output:"Ifmmp*3"

Input:"fun times!"
Output:"gvO Ujnft!"

*/
class MainClass
{
    public static string LetterChanges(string str)
    {
        string res="";
        byte chr = 0;
        char c;

        for (int i = 0; i < str.Length; i++)
        {
            if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
            {
                chr = Convert.ToByte(str[i]);

                if (str[i] == 'z')
                {
                    c = 'a';
                }
                else if (str[i] == 'Z')
                {
                    c = 'A';
                }
                else
                    c = Convert.ToChar(chr + 1);


                if ("aeiou".IndexOf(c) >= 0)
                {
                    res += Char.ToUpper(c);
                }
                else
                    res += c;
            }
            else
                res += str[i];
        }
        return res;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(LetterChanges(Console.ReadLine()));
    }

}