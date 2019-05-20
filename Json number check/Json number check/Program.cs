﻿using System;

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
            if (!CheckIfCorrectCharacters(line)) return false;
            if (!CheckBeforeTheE(line)) return false;
            if (!CheckAfterTheE(line)) return false;
            return true;
        }

        public static bool CheckIfCorrectCharacters(string line)
        {
            string correctCharacters = "0123456789.-+Ee";
            for(int i=0;i<line.Length;i++)
            {
                bool check = false;
                for(int j=0;j<correctCharacters.Length;j++)
                {
                    if(line[i]==correctCharacters[j])
                    {
                        check = true;
                    }
                }
                if (check == false) return false;
            }
            return true;
        }

        public static bool CheckBeforeTheE(string line)
        {
            if ((line[0] == '0'&&line[1]!='.')||line[0]=='+'||line[0]=='.') return false;
            if (line[0] == '-' && line[1] == '0' && line[2] != '.') return false;
            int count = 0;
            for(int i=1;i<line.Length;i++)
            {
                if (line[i] == 'e' || line[i] == 'E') break;
                if (line[i] == '-' || line[i] == '+') return false;
                if(line[i]=='.')
                {
                    count++;
                    bool check1 = false, check2=false;
                    for(int j=0;j<=9;j++)
                    {
                        if(line[i+1].ToString()==j.ToString())
                        {
                            check1 = true;
                        }
                        if (line[i-1].ToString() == j.ToString())
                        {
                            check2 = true;
                        }

                    }
                    if (!check1||!check2) return false;
                }
            }
            if (count > 1) return false;
            return true;
        }
        public static bool CheckAfterTheE(string line)
        {
            int plus = 0, minus = 0, firstE = -1,dot=0 ;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'e' || line[i] == 'E')
                {
                    firstE = i;
                    break;
                }
            }
            if (firstE == -1) return true;
            if (firstE == 0) return false;
            if (firstE == 1 && line[0] == '-') return false;
            if (firstE == line.Length - 1) return false;
            for(int i=firstE+1;i<line.Length;i++)
            {
                if (line[i] == '+') plus++;
                if (line[i] == '-') minus++;
                if (line[i] == '.') dot++;
                if (line[i] == 'e' || line[i] == 'E') return false; ;
                if (plus > 1 || minus > 1) return false;
                if (plus > 0 && minus > 0) return false;
                if (dot > 1) return false;
            }
            if (line[firstE + 1] == '.') return false;
            if(plus==1||minus==1)
            {
                if (line[firstE + 1] != '+' && line[firstE+1] != '-')
                    return false;
                if (line[firstE + 2] == '.') return false; 
            }
            return true;

        }
    }
}