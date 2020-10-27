namespace Utility
{
    public static class Characters
    {
        private const int LetterCodeEnglishCaseCharactersOffsetDifference = 32;

        public static char ToOtherCase(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return (char)(c - LetterCodeEnglishCaseCharactersOffsetDifference);
            }
            if (c >= 'A' && c <= 'Z')
            {
                return (char)(c + LetterCodeEnglishCaseCharactersOffsetDifference);
            }
            return c;
        }
    }
}