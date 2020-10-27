using System;

namespace Utility
{
    public static class Strings
    {
        public static int CountOf(this string s, string value)
        {

            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int segmentLength = value.Length;
            int stringlength = s.Length;
            if (stringlength == 0 || segmentLength == 0)
            {
                return 0;
            }

            int segmentCount = 0;
            int segmentMatchIndex = 0;
            for (int i = 0; i < stringlength; i++)
            {
                if (s[i] == value[segmentMatchIndex])
                {
                    segmentMatchIndex++;
                    if (segmentMatchIndex == segmentLength)
                    {
                        segmentCount++;
                        segmentMatchIndex = 0;
                    }
                }
                else if (segmentMatchIndex > 1)
                {
                    segmentMatchIndex = 0;
                }
            }

            return segmentCount;
        }

        public static bool EndsWith(this string s, char c)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return s.Length > 0 && s[^1] == c;
        }

        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, true) == 0;
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsPalindrome(this string s)
        {
            int stringLength = s.Length;
            int iterationCount = stringLength / 2;
            for (int i = 0; i <= iterationCount; i++)
            {
                if (s[i] != s[stringLength - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static string Reverse(this string s)
        {
            int length = s.Length;
            char[] charArr = new char[length];
            for (int i = length - 1, j = 0; i > 0; i--, j++)
            {
                charArr[j] = s[i];
            }

            return new string(charArr);
        }
    }
}