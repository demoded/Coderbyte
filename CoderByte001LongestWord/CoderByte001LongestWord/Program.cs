using System;
/*
https://www.coderbyte.com/editor/guest:Longest%20Word:Csharp
Using the C# language, have the function  LongestWord(sen) take the sen parameter being passed and return the largest word in the string. 
If there are two or more words that are the same length, return the first word from the string with that length. 
Ignore punctuation and assume sen will not be empty. 
 
Sample Test Cases
Input:"fun&!! time"
Output:"time"

Input:"I love dogs"
Output:"love"

*/
class MainClass
{
    public static string LongestWord(string sen)
    {
        int count = 0, pos = 0, longest = 0,  longestEndPos = 0;
        string res = "";

        for (int i = 0; i < sen.Length; i++)
        {
            if (sen[i] >= 'A' && sen[i] <= 'Z' || sen[i] >= 'a' && sen[i] <= 'z')
                count++;
            else
            {
                if (count > longest)
                {
                    longest = count;
                    longestEndPos = i;
                }

                count = 0;
            }
        }

        if (count > longest)
        {
            longest = count;
            longestEndPos = sen.Length;
        }

        for (int i = longest; i > 0; i--)
            res = res + sen[longestEndPos - i];
        return res;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(LongestWord(Console.ReadLine()));
    }

}
