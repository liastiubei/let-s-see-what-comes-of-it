using System;

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
            return HasQuotationMarksInBeginningAndEnd(jsonString)
                && CharactersBiggerThan31(jsonString)
                && CheckTheBackslash(jsonString)
                && CorrectQuotationMarks(jsonString);
        }

        private static bool CorrectQuotationMarks(string jsonString)
        {
            for (int i = 1; i < jsonString.Length - 1; i++)
            {
                if (jsonString[i] == '\"' && jsonString[i - 1] != '\\')
                    return false;
            }
            return true;
        }

        private static bool CharactersBiggerThan31(string jsonString)
        {
            for (int i = 0; i < jsonString.Length; i++)
            {
                if (jsonString[i] < 32) return false;
            }
            return true;
        }

        private static bool HasQuotationMarksInBeginningAndEnd(string jsonString)
        {
            return jsonString[0] == '\"'
                && jsonString[jsonString.Length - 1] == '\"';
        }

        public static bool CheckTheBackslash(string jsonString)
        {
            string whatBackslashContainsAfter = "\"\\\u002Fbfnrt";
            for (int i = 0; i < jsonString.Length - 1; i++)
            {
                bool p = false;int k = 0;
                if (jsonString[i] == '\\')
                {
                    if (i > jsonString.Length - 3)
                        return false;
                    if(whatBackslashContainsAfter.Contains(jsonString[i+1]))
                    {
                        p = true; k = 1;
                    }
                    if (jsonString[i + 1] == 'u')
                    {
                        if (jsonString.Length - i - 2 < 4)
                            return false;
                        int nr = 0;
                        for (int j = i + 2; j < i + 6; j++)
                        {
                            if ((jsonString[j] >= 48 && jsonString[j] <= 57)
                                || (jsonString[j] >= 65 && jsonString[j] <= 90)
                                || (jsonString[j] >= 97 && jsonString[j] <= 122))
                                    nr++;
                        }
                        if (nr == 4)
                        {
                            p = true; k = 4;
                        }
                    }
                    if (!p) return false;
                }
                i += k;
            }
            return true;
        }
    }
}
