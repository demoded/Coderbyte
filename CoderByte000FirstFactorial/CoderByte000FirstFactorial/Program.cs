using System;
/*
https://www.coderbyte.com/editor/guest:First%20Factorial:Csharp
Using the C# language, have the function  FirstFactorial(num) take the num parameter being passed and return the factorial of it
(e.g. if num = 4, return (4 * 3 * 2 * 1)). For the test cases, the range will be between 1 and 18 and the input will always be an integer. 
 
Sample Test Cases
Input:4
Output:24

Input:8
Output:40320

*/
class MainClass
{
    public static int FirstFactorial(int num)
    {

        // code goes here  
        /* Note: In C# the return type of a function and the 
           parameter types being passed are defined, so this return 
           call must match the return type of the function.
           You are free to modify the return type. */
        if (num > 1)
            return num * FirstFactorial(num - 1);
        else
            return 0;
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(FirstFactorial(Convert.ToInt16(Console.ReadLine())));
    }

}
