using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Core
{
    public static class Day4
    {
        public static bool IsValidPassword(int number)
        {
            bool duplicates, decrease;
            GetDuplicateAndDecrease(number, out duplicates, out decrease);

            if (!duplicates || decrease)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidPasswordAdvanced(int number)
        {
            bool duplicates, decrease;
            GetDuplicateAndDecrease(number, out duplicates, out decrease);

            if (!duplicates || decrease)
            {
                return false;
            }

            string numberAsString = number.ToString();
            int p = 1;
            char actual = numberAsString[0];
            int group = 0;
            bool twoLengthGroups = false;
            while (p < numberAsString.Length)
            {
                while (p < numberAsString.Length && numberAsString[p] == actual)
                {
                    group++;
                    p++;
                }

                if (group == 1)
                {
                    twoLengthGroups = true;
                }

                if (p + 1 < numberAsString.Length)
                {
                    group = 0;
                    actual = numberAsString[p];
                    p++;
                }
                else
                {
                    p++;
                }
            }

            return twoLengthGroups;
        }

        private static void GetDuplicateAndDecrease(int number, out bool ddouble, out bool decrease)
        {
            string numberAsString = number.ToString();
            ddouble = false;
            decrease = false;
            for (int i = 0; i < numberAsString.Length - 1; i++)
            {
                if (numberAsString[i] == numberAsString[i + 1])
                    ddouble = true;

                if (numberAsString[i] > numberAsString[i + 1])
                {
                    decrease = true;
                }
            }
        }
    }
}
