using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@Console.ReadLine());
            Json.Value newValue = new Json.Value();
            Console.WriteLine(newValue.Match(text).Success());
            Console.Read();
        }
    }
}
