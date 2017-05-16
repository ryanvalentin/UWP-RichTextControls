using System;

public class Hello
{
    public static void Main(string[] args)
    {
        // This is a comment
        Console.WriteLine("Hello, World!");
        Console.WriteLine("You entered the following {0} command line arguments:",
           args.Length);
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("{0}", args[i]);
        }
    }
}