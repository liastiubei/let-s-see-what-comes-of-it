using System;

namespace Json_number_check
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (JsonNumCheck(Console.ReadLine()))
            {
                Console.WriteLine("Valid");
            }
            else Console.WriteLine("Invalid");
            Console.Read();
        }

        public static bool JsonNumCheck(string line)
        {
            return CheckIfCorrectCharacters(line)
                && CheckBeforeTheE(line)
                && CheckAfterTheE(line);
        }

        public static bool CheckIfCorrectCharacters(string line)
        {
            string correctCharacters = "0123456789.-+Ee";
            foreach(char c in line)
            {
                if (!correctCharacters.Contains(c)) return false;
            }
            return true;
        }

        public static bool CheckBeforeTheE(string line)
        {
            if (HasLeadingZeroWithoutDot(line) || StartsWithAny(line, "+."))
                return false;
            if (HasLeadingMinusFollowedByZeroWithoutDot(line))
                return false;
            if (HasTooManyMinusPlusOrDots(line)) return false;
            return true;
        }

        private static bool HasTooManyMinusPlusOrDots(string line)
        {
            bool count=false;
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == 'e' || line[i] == 'E') break;
                if (line[i] == '-' || line[i] == '+') return true;
                if (line[i] == '.')
                {
                    if (count) return true;
                    count = true;
                    if (!"0123456789".Contains(line[i - 1]) || !"0123456789".Contains(line[i + 1])) return true;
                }
            }
            return false;
        }

        private static bool HasLeadingMinusFollowedByZeroWithoutDot(string line)
        {
            return line.Length > 2
                && line[0] == '-'
                && line[1] == '0'
                && line[2] != '.';
        }

        private static bool StartsWithAny(string line, string input)
        {
            return line.Length > 0 && input.Contains(line[0]);
        }

        private static bool HasLeadingZeroWithoutDot(string line)
        {
            return line.Length > 1 
                && line[0] == '0'
                && line[1] != '.';
        }

        public static bool CheckAfterTheE(string line)
        {
            int firstE = -1 ;
            FindFirstE(ref firstE, line);
            if (firstE == -1) return true;
            if (!EIsInTheCorrectSpot(line, firstE)) return false;
            if (!CorrectPlusMinusEsOrDots(line, firstE)) return false;
            return true;
        }

        private static bool CorrectPlusMinusEsOrDots(string line, int firstE)
        {
            int plus = 0, minus = 0, dot = 0;
            if (line[firstE + 1] == '.')
                return false;
            for (int i = firstE + 1; i < line.Length; i++)
            {
                if (line[i] == '+') plus++;
                if (line[i] == '-') minus++;
                if (line[i] == '.') dot++;
                if (line[i] == 'e' || line[i] == 'E')
                    return false; ;
                if (plus > 1 || minus > 1||(plus > 0 && minus > 0)||dot>1)
                    return false;
            }
            if (plus == 1 || minus == 1)
            {
                if (!"+-".Contains(line[firstE + 1]))
                    return false;
                if (line[firstE + 2] == '.')
                    return false;
            }
            return true;
        }

        private static void FindFirstE(ref int firstE, string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'e' || line[i] == 'E')
                {
                    firstE = i;
                    break;
                }
            }
        }

        private static bool EIsInTheCorrectSpot(string line, int firstE)
        {
            if (firstE == 0) return false;
            if (firstE == 1 && line[0] == '-') return false;
            if (firstE == line.Length - 1) return false;
            return true;
        }
    }
}
