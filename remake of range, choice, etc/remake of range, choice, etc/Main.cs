using System;

namespace RemakeOfRangeChoiceEtc
{
    class ReadFromFile
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@Console.ReadLine());
            var value = new Value();
            Console.WriteLine(value.Match(text).Success());
            Console.Read();
        }
    }
}