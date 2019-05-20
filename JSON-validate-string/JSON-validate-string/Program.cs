﻿using System;

namespace JSON_validate_string
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (CheckIfValidString(Console.ReadLine())) Console.WriteLine("Valid");
            else Console.WriteLine("Invalid");
            Console.Read();
            
        }
        public static bool CheckIfValidString(string jsonString)
        {
            if (jsonString[0] != '\"' || jsonString[jsonString.Length-1] != '\"') return false;
            for(int i=0;i<jsonString.Length;i++)
            {
                if (jsonString[i] < 32) return false;
            }
            if (CheckTheBackslash(jsonString) == false) return false;
            for(int i=1;i<jsonString.Length-1;i++)
            {
                if(jsonString[i]=='\"')
                {
                    if (jsonString[i - 1] != '\\') return false;
                }
            }
            return true;
        }
        public static bool CheckTheBackslash(string jsonString)
        {
            char[] backslash = { '\"', '\\', '\u002F', 'b', 'f', 'n', 'r', 't' };
            for (int i = 0; i < jsonString.Length - 1; i++)
            {
                bool p = false;int k = 0;
                if (jsonString[i] == '\\')
                {
                    if (i > jsonString.Length - 3) return false;
                    for (int j = 0; j < backslash.Length; j++)
                    {
                        if (jsonString[i + 1] == backslash[j])
                        { p = true; k = 1; }
                    }
                    if (jsonString[i + 1] == 'u')
                    {
                        if (jsonString.Length - i - 2 < 4) return false;
                        int nr = 0;
                        for (int j = i + 2; j < i + 6; j++)
                        {
                            if (jsonString[j] >= 48 && jsonString[j] <= 57) nr++;
                            if (jsonString[j] >= 65 && jsonString[j] <= 90) nr++;
                            if (jsonString[j] >= 97 && jsonString[j] <= 122) nr++;
                        }
                        if (nr == 4) { p = true; k = 4; }
                    }
                    if (p == false) return false;
                }
                i = i + k;
            }
            return true;
        }
    }
}